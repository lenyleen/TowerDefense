using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    private Button button;
    private Image cooldown;
    private const float CoolDownTimer = 4.0f;
    private float startCoolDown;
    [SerializeField]private int price;
    public static event Action<int> buttonAction;
    private void OnEnable()
    {
        button = this.GetComponent<Button>();
        cooldown = button.transform.GetChild(1).GetComponent<Image>();
        button.onClick.AddListener(CoolDown);
    }

    private void CoolDown()
    {
        startCoolDown = 4.0f;
        buttonAction?.Invoke(price);
    }
    
    private void Update()
    {
        if (price > CoinCounter.coinAmount)
        {
            button.interactable = false;
            return;
        }
        button.interactable = true;
        if (!(startCoolDown > 0)) return;
        startCoolDown -= Time.deltaTime;
        cooldown.fillAmount = startCoolDown / CoolDownTimer;
        button.interactable = false;
    }
}


    
