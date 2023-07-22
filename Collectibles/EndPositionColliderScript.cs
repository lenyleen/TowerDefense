using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPositionColliderScript : MonoBehaviour
{
    private void OnEnable()
    {
        BaseUfo.ufoAction += HeartAttack;
    }

    private void HeartAttack()
    {
        var heart= SingletonUFOs.instance.GetHeart(this.transform);
        heart.SetActive(true);
    }
}
