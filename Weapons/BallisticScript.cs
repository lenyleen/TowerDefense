using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public  class BallisticScript : MonoBehaviour
{
    private Transform Target;
    public Transform Cannon;
    private Vector3 FromTo;
    private Vector3 fromXtoZ;
    private const float angleInDeg = 40f;
    public GameObject Bullet;
    private Rigidbody BulletRb;
    private bool cour = true;
    private Vector3 leadPos;
    private Vector3 LastEnemPos;
    private Collider[] colliders;
    private float g => Physics.gravity.y;
    [SerializeField] private LayerMask enemy_layer;
    private void Update()
    {
        Target = TryToFind();
        if (Target == null) return;
        leadPos = Target.parent.GetComponent<NavMeshAgent>().velocity;
        FromTo = (Target.transform.position + leadPos) - this.transform.position;
        fromXtoZ = new Vector3(FromTo.x, 0f, FromTo.z);
        var x = fromXtoZ.magnitude;
        var y = FromTo.y;
        var h = Target.transform.position.y - this.transform.position.y;
        Cannon.localEulerAngles = new Vector3(angleInDeg, 0, 0);
        if (cour)
        {
            StartCoroutine(Shot(x, y, h));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(new Vector3(this.transform.position.x, 0.2f, this.transform.position.z),3f);
    }

    private IEnumerator Shot(float x, float y, float h)
    {
        cour = false;
        this.transform.rotation = Quaternion.LookRotation(fromXtoZ, Vector3.up);
        LastEnemPos = Target.position;
        var AngleInRad = Cannon.localEulerAngles.x * Mathf.Deg2Rad;
        var v2 = (g * x * x) / ((x * Mathf.Sin(2 * AngleInRad)) - (y * Mathf.Pow(Mathf.Cos(AngleInRad), 2)));
        var v = Mathf.Sqrt(Mathf.Abs(v2));
        var newBul = BulletPool.instance.GetBullet(Cannon);
        newBul.SetActive(true);
        newBul.GetComponent<Rigidbody>().velocity = Cannon.up * Mathf.Abs(v);
        yield return new WaitForSeconds(1f);
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
