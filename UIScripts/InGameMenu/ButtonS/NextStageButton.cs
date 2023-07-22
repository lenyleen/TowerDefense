using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextStageButton : MonoBehaviour
{
    private string stageName;
    private string nextStageName;
    private Button button;

    private void OnEnable()
    {
        stageName = SceneManager.GetActiveScene().name;
        nextStageName = Convert.ToString(Convert.ToInt32(stageName) + 1);
        button = this.GetComponent<Button>();
        button.onClick.AddListener(delegate { FindObjectOfType<StageFader>().LoadStage(nextStageName);});;
    }
}
