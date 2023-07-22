using System;
using UnityEngine;

public class WaterMillRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private void FixedUpdate()
    {
        this.transform.Rotate(Vector3.left, rotationSpeed);
    }
}
