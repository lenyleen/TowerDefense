using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    private Button resumeButton => this.GetComponent<Button>();
    private GameObject inGameMenu => this.transform.parent.gameObject;

    private void OnEnable()
    {
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void ResumeGame()
    {
        inGameMenu.SetActive(false);
    }
}
