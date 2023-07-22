using UnityEngine;
public class TestMover : CollectiblesMove
{
    private new Vector3 p4 => Camera.main.ScreenToWorldPoint(GameObject.FindObjectOfType<CoinCounter>(true).transform.position);
    protected override void FixedUpdate()
    {
        base.SpeedCalculating();
        this.transform.eulerAngles += new Vector3(0f, 0f, 2f);
        scaleOfCollectible = new Vector3(t, t, t);
        this.transform.position = Bezier.GetPoint(base.p1, base.p2.position, base.p3.position, p4, t);
    }
}
