using System;
using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private float delay = 10f;
    private GameObject takingHead => FindObjectOfType<TalkingHeadTips>(true).transform.parent.gameObject;
    private void OnEnable()
    {
        StartCoroutine(StartTimer());
    }
    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(delay);
        if (FindObjectOfType<AvalableToBuildGround>() == null)
        {
            takingHead.SetActive(true);
            FindObjectOfType<TalkingHeadTips>().ShowSimpleMessage();
            yield return new WaitForSeconds(delay);
            takingHead.SetActive(false);
        }
        
    }
}
