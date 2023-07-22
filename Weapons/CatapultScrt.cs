using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatapultScrt : MonoBehaviour
{
    public Transform Catapult;
    public Transform stonePos;
    private float h, g, L, v;
    private Vector3 FromTo;
    private Vector3 fromXtoZ;
    private bool cour = true;
    private Animator anim;
    private Vector3 leadPos;
    private Transform Target;
    private Collider[] colliders;
    [SerializeField] private LayerMask enemy_layer;
    private  void Start()
    {
        g = Physics.gravity.y;
       anim = Catapult.GetComponent<Animator>();
    }
    private void Update()
    {
        Target = TryToFind();
        if (Target == null) return;
        leadPos = Target.parent.GetComponent<NavMeshAgent>().velocity;
        FromTo = (Target.position + leadPos / 1.5f) - stonePos.position;
        fromXtoZ = new Vector3(FromTo.x, 0f, FromTo.z);
        L = FromTo.y;
        h = fromXtoZ.magnitude;
        if (cour)
        {
            StartCoroutine(Shot(L, h));
        }
    }

    private IEnumerator Shot(float h, float L)
    {
        cour = false;
        anim.Play("CtapultAnim");
        yield return new WaitForSeconds(0.2f);
        this.transform.rotation = Quaternion.LookRotation(fromXtoZ,Vector3.up);
        v = Mathf.Abs(L) * Mathf.Sqrt(Mathf.Abs(g/(2*h)));
        var _stone = BulletPool.instance.GetStone(stonePos);
        _stone.SetActive(true);
        _stone.GetComponent<Rigidbody>().velocity = this.transform.forward * v;
        yield return new WaitForSeconds(1f);
        cour = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(this.transform.position.x, 0.2f, this.transform.position.z),3f);
    }

    private Transform TryToFind()
    {
        try
        {
            colliders = Physics.OverlapSphere(new Vector3(this.transform.position.x, 0.2f, this.transform.position.z),
                1f,enemy_layer);
            return colliders[colliders.Length - 1].gameObject.transform;
        }
        catch
        {
            return null;
        }
    }
}
