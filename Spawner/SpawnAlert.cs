using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlert : MonoBehaviour
{
    private SpriteRenderer alertSprite => this.gameObject.GetComponent<SpriteRenderer>();
    [SerializeField] private AnimationCurve fadeCurve;
    [Range(0, 1), SerializeField] private float aColor;
    private void OnEnable()
    {
        alertSprite.color = new Color(alertSprite.color.r, alertSprite.color.g, alertSprite.color.b, 0f);
        StartCoroutine(AlertFade());
    }

    private IEnumerator AlertFade()
    {
        while (aColor < 4)
        {
            aColor += 0.01f;
            var a = fadeCurve.Evaluate(aColor);
            var color = alertSprite.color;
            alertSprite.color = new Color(color.r, color.g, color.b, a);
            yield return 0;
        }
        this.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        aColor = 0f;
    }
}
