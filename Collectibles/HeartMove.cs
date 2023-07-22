using System;
using UnityEngine;

public class HeartMove : CollectiblesMove
{
    private new Vector3 p4 => Camera.main.ScreenToWorldPoint(GameObject.FindObjectOfType<LifeCounter>(true).transform.position);
    public static event Action AddColectible;
    protected override void FixedUpdate()
    {
        SpeedCalculating();
        this.transform.eulerAngles += new Vector3(0f, 0f, 2f);
        scaleOfCollectible = new Vector3(t, t, t);
        this.transform.position = Bezier.GetPoint(base.p1, base.p2.position, base.p3.position, p4, t);
    }

    private new void SpeedCalculating()
    {
        if (t < 1)
            t += collectibleSpeedCurve.Evaluate(colectibleSpeed);
        else
        {
            AddColectible?.Invoke();
            t = 0f;
            this.gameObject.SetActive(false);
        }
    }
}
