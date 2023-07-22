using System;
using System.Collections.Generic;
using UnityEngine;


public class Level_Manager : MonoBehaviour
{
    private List<StageButton> stages = new List<StageButton>();

    private void OnEnable()
    {
        stages.AddRange(FindObjectsOfType<StageButton>(true));
    }

    private void Start()
    {
        var levelReached = PlayerPrefs.GetInt("levelReached", 0);
        for (var i = 0; i < stages.Count; i++)
        {
            var stageNumber = Convert.ToInt32(stages[i].stageNumber);
            if (stageNumber > levelReached)
            {
                stages[i].Lock();
                stages[i].button.interactable = false;
                continue;
            }
            stages[i].Unlock();
        }
    }
}
