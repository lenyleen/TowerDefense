using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class AvalableToBuildGround : MonoBehaviour
{
    [Header ("Statements")] 
    private TowerStateMachine stateMachine;
    public RedHihlightState reded;
    public GreenHighlightState greened;
    public NormalColorsTowerState dropped;
    private MouseClickManager mouseManager;
    [Header ("Material & Colors")]
    public Material HighlightedGreen;
    public Material HighlightedRed;
    public Material[][] allMaterials;
    public List<Color> col = new List<Color>();
    [Header ("GameObjectShit")]
    public Transform RayCastPoint;
    public LayerMask ground;
    public Transform towerTOp;
    [FormerlySerializedAs("DetectedGround")] public bool detectedGround;
    private GameObject weapon;
    public Action drop;
    private RaycastHit dropPoint;
    private void OnEnable()
    {
        mouseManager = MouseClickManager.mouseManager;
        weapon = this.transform.GetChild(3).gameObject;
        AddToRange(towerTOp.gameObject.GetComponent<MeshRenderer>().materials);
        AddToRange(towerTOp.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().materials);
        AddToRange(towerTOp.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().materials);
        allMaterials = new Material[][] {towerTOp.gameObject.GetComponent<MeshRenderer>().materials, towerTOp.transform.GetChild(1).gameObject.GetComponent<MeshRenderer>().materials, towerTOp.transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().materials };
        stateMachine = new TowerStateMachine();
        reded = new RedHihlightState(this,stateMachine);
        greened = new GreenHighlightState(this,stateMachine);
        dropped = new NormalColorsTowerState(this,stateMachine);
        stateMachine.Initialize(reded);
        drop += EnableWeapon;
    }

    private void Update()
    {
        stateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate() {
        detectedGround = Physics.Raycast(RayCastPoint.position,Vector3.down,out dropPoint,5f,ground);
        stateMachine.CurrentState.PhysicsUpdate();
    }
    private void OnDrawGizmos() {
        Gizmos.DrawRay(RayCastPoint.position,Vector3.down);
    }
    public void ChangeRenderingMode(Material[][] curMaterial,List<Color> origMaterial)
    {
        for (var i = 0; i < allMaterials.Length; i++)
        {
            for (var j = 0; j < allMaterials[i].Length; j++)
            {
                curMaterial[i][j].SetFloat("_Mode", 0);
                curMaterial[i][j].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                curMaterial[i][j].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                curMaterial[i][j].SetInt("_ZWrite", 0);
                curMaterial[i][j].DisableKeyword("_ALPHATEST_ON");
                curMaterial[i][j].EnableKeyword("_ALPHABLEND_ON");
                curMaterial[i][j].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                curMaterial[i][j].renderQueue = 3000;  
                curMaterial[i][j].color = origMaterial[i+j];
            }
        }
    }
    public void ChangeRenderingMode(Material[][] curMaterial, Color Highlighted)
    {
        for (var i = 0; i <allMaterials.Length; i++)
        {
            for (var j = 0; j < allMaterials[i].Length; j++)
            {
                curMaterial[i][j].SetFloat("_Mode", 2);
                curMaterial[i][j].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                curMaterial[i][j].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                curMaterial[i][j].SetInt("_ZWrite", 0);
                curMaterial[i][j].DisableKeyword("_ALPHATEST_ON");
                curMaterial[i][j].EnableKeyword("_ALPHABLEND_ON");
                curMaterial[i][j].DisableKeyword("_ALPHAPREMULTIPLY_ON");
                curMaterial[i][j].renderQueue = 3000;  
                curMaterial[i][j].color = Highlighted;
            }
        }
    }

    private void OnMouseDrag()
    {
        if(stateMachine.CurrentState != dropped)
        {
            this.transform.position = new Vector3(mouseManager.neededPoint.transform.position.x, this.transform.position.y,
            mouseManager.neededPoint.transform.position.z);
        }
    }

    private void OnMouseUp()
    {
        if (stateMachine.CurrentState != greened || this == null) return;
        dropPoint.transform.gameObject.layer = this.gameObject.layer;
        drop?.Invoke();
    }

    private void AddToRange(IEnumerable<Material> curMaterial)
    {
        foreach (var v in curMaterial)
        {
            col.Add(v.color);
        }
    }

    private void EnableWeapon()
    {
        if(this != null)
        weapon?.SetActive(true);
    }
}


