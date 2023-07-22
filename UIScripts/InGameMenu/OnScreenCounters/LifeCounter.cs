using System;
using TMPro;
using UnityEngine;

public class LifeCounter : MonoBehaviour
{
    private static TextMeshProUGUI text;
    private static int heartssAmount { get; set; }
    public static Action healthAction;
    private void OnEnable()
    {
        heartssAmount = 3;
        text = this.GetComponent<TextMeshProUGUI>();
        text.text = Convert.ToString(heartssAmount);
        HeartMove.AddColectible += DecreaseCoinAmount;
    }
    private void DecreaseCoinAmount()
    {
        if (heartssAmount <= 1)
        {
            healthAction?.Invoke();
        }
        heartssAmount--;
        text.text = Convert.ToString(heartssAmount);
    }
    private void OnDisable()
    {
        HeartMove.AddColectible -= DecreaseCoinAmount;
    }
}
