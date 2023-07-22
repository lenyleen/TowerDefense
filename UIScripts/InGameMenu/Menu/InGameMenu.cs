using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]private Button pauseButton;
    [SerializeField] private GameObject inGameMenu;

    private void OnEnable()
    {
        pauseButton.onClick.AddListener(InvokeMenu);
    }

    private void InvokeMenu()
    {
        inGameMenu.SetActive(!inGameMenu.activeInHierarchy);
    }
}
