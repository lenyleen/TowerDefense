using System;
using UnityEngine;
using UnityEngine.UI;

public class StagesButton : MonoBehaviour
{ 
    [SerializeField] private GameObject stagesPlane;
    private Button button => this.GetComponent<Button>();

    private void OnEnable()
    {
        button.onClick.AddListener(ActivatePlane);
    }

    private void ActivatePlane()
    {
        stagesPlane.SetActive(!stagesPlane.activeInHierarchy);
    }
}
