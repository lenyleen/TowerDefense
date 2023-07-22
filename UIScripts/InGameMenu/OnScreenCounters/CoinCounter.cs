using System;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    private static TextMeshProUGUI text;
    public static int coinAmount { get; private set; }

    private void OnEnable()
    {
        coinAmount = 10;
        text = this.GetComponent<TextMeshProUGUI>();
        text.text = Convert.ToString(coinAmount);
        TestMover.addColectible += ChangeColectibleAmount;
        ButtonScript.buttonAction += DecreaseCoinAmount;
        BaseUfo.ufoAction += ChangeColectibleAmount;
    }

    private void ChangeColectibleAmount()
    {
        coinAmount += 2;
        text.text = Convert.ToString(coinAmount);
    }

    private void DecreaseCoinAmount(int towerPrice)
    {
        coinAmount -= towerPrice;
        text.text = Convert.ToString(coinAmount);
    }
    private void OnDisable()
    {
        TestMover.addColectible -= ChangeColectibleAmount;
        ButtonScript.buttonAction -= DecreaseCoinAmount;
        BaseUfo.ufoAction -= ChangeColectibleAmount;
    }
}
