using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class BallistaScr : MonoBehaviour
{
    public GameObject Arrow;
    public Transform Bow;
    private Transform Target;
    private float h, L, v;
    private Vector3 FromTo;
    private Vector3 fromXtoZ;
    private bool cour = true;
    private Vector3 leadPos;
    private Collider[] colliders;
    [SerializeField] private LayerMask enemy_layer;
    private Vector3 EulerEnglesOnStart => this.transform.eulerAngles;
    private float g => Physics.gravity.y;
    private void Update()
    {
        
        Target = TryToFind();
        if (Target == null) return;
        leadPos = Target.parent.GetComponent<NavMeshAgent>().velocity;
        FromTo = (Target.position + leadPos/2) - this.transform.position;
        fromXtoZ = new Vector3(FromTo.x,0f,FromTo.z);
        L = FromTo.y;
        h = fromXtoZ.magnitude;
        if (cour)
        {
            StartCoroutine(Shot(L,h));
        }
    }

    private IEnumerator Shot(float h, float L)
    {
        cour = false;
        this.transform.rotation = Quaternion.LookRotation(fromXtoZ,Vector3.up);
        v = Mathf.Abs(L) * Mathf.Sqrt(Mathf.Abs(g/(2*h)));
        var newArr = BulletPool.instance.GetArrow(Bow);
        newArr.transform.eulerAngles = Bow.transform.eulerAngles;
        newArr.SetActive(true);
        newArr.GetComponent<Rigidbody>().velocity = Bow.forward * v;
        newArr.GetComponent<Rigidbody>().angularVelocity = Vector3.right * 1.03f;
        yield return new WaitForSeconds(1.5f);
        cour = true;
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
