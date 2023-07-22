using System;
using UnityEngine;

public sealed class MouseClickManager : MonoBehaviour
{
    private MouseClickManager()
    {
    }

    public static MouseClickManager mouseManager;

    private void OnEnable()
    {
        if (mouseManager == null) mouseManager = this;
    }

    public Vector3 MouseRayDirection { get; private set; }

    public Vector3 mousePos {get; private set;}
    private Camera mainCamera => Camera.main; 
    private const float cameraAngle = 208.614f;
    private RaycastHit pointOfMouse;
    public GameObject neededPoint;
    private void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        MouseRayDirection = new Vector3(Mathf.Tan(cameraAngle * Mathf.Deg2Rad) * mousePos.y * 2,Mathf.Cos(cameraAngle * Mathf.Deg2Rad) * mousePos.y *2,0);
        Debug.Log(MouseRayDirection);
        Debug.DrawRay(mousePos,MouseRayDirection);
        if(Physics.Raycast(mouseManager.mousePos,MouseRayDirection.normalized,out pointOfMouse,14f))
        {
            neededPoint = pointOfMouse.collider.gameObject;
        }
    }
}   
