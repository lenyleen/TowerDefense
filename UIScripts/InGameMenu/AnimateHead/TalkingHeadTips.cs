using System;
using System.Collections;
using System.Text;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class TalkingHeadTips : MonoBehaviour
{
    private string message = "Put some tower anywhere, to start the game";
    private TextMeshProUGUI we => this.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    public Animator anim;
    public Action tipsAction;
    private IEnumerator OutputMessage(string message)
    {
        we.text = new string(new char[]{});
        anim.SetBool("Talking", true);
        foreach (var c in message)
        {
            we.text += c;
            yield return new WaitForSeconds(0.07f);
        }
        anim.SetBool("Talking", false);
        yield return new WaitForSeconds(2f);
        tipsAction?.Invoke();
    }
    public void ShowSimpleMessage()
    {
        StartCoroutine(OutputMessage(message));
    }

    public void ShowMessage(string message)
    {
        StartCoroutine(OutputMessage(message));
    }
}
