using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AbstractTower : MonoBehaviour
{
    [SerializeField]protected LayerMask enemy_layer;
    protected float g => Physics.gravity.y;
    protected virtual void Start()
    {}
    protected virtual void Update()
    {}
    protected virtual IEnumerator Shot(float h, float L)
    {yield return new WaitForSeconds(0f);}
    protected virtual Transform TryToFind()
    {
        return null;
    }
}
