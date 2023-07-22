using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    private Button mainMenuButton;
    private void OnEnable()
    {
        mainMenuButton = this.GetComponent<Button>();
        mainMenuButton.onClick.AddListener(delegate { FindObjectOfType<StageFader>().LoadStage("Main Menu"); });
    }

    private void OnDisable()
    {
        mainMenuButton.onClick.RemoveAllListeners();
    }
}
