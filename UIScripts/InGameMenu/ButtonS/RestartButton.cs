using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    private Button restartButton => this.GetComponent<Button>();

    private void OnEnable()
    {
        restartButton.onClick.AddListener(RestartLvl);
    }

    private void RestartLvl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
