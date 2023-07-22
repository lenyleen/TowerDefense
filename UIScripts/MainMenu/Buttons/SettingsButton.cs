using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
public class SettingsButton : MonoBehaviour
{
    private Button settings => this.GetComponent<Button>();
    private List<GameObject> sound_musicButtons = new List<GameObject>();
    [SerializeField] private int delayInMs;

    private void OnEnable()
    {
        
        for (var i = 0; i < this.transform.childCount; i++)
        {
            sound_musicButtons.Add(this.transform.GetChild(i).gameObject);
        }
        settings.onClick.AddListener(ActivateChildButtons);
    }

    private async void ActivateChildButtons()
    {
        foreach (var button in sound_musicButtons)
        {
            await WhatButtonActivate(button);
        }
    }

    private async Task WhatButtonActivate(GameObject button)
    {
        button.SetActive(!button.activeInHierarchy);
        await Task.Delay(delayInMs);
    }
}
