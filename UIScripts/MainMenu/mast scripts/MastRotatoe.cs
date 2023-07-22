using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MastRotatoe : MonoBehaviour
{
    public float rotationSpeed = 1f;
    private void FixedUpdate()
    {
        this.transform.Rotate(Vector3.up,rotationSpeed);
    }
}
