using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageButton : MonoBehaviour
{
   [SerializeField] public Button button;
   [SerializeField] private TextMeshProUGUI StageText;
   [SerializeField] public string stageNumber;
   [SerializeField] private Image _lock;
   [SerializeField] private Sprite unlock;
   [SerializeField] private Sprite _locked;
   private void OnEnable()
   {
      button.onClick.AddListener(delegate { FindObjectOfType<StageFader>().LoadStage(stageNumber);});
      if (Convert.ToInt32(stageNumber) == 0)
      {
         StageText.text = "Tutorial";
         return;
      }
      StageText.text = "Stage " + stageNumber;
   }

   public void Lock()
   {
      _lock.sprite = _locked;
   }

   public void Unlock()
   {
      _lock.sprite = unlock;
   }
}
