using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class CollectiblesMove : MonoBehaviour
{
    protected Vector3 p1;
    protected Transform p2 => GameObject.Find("p2").transform;
    protected Transform p3 => GameObject.Find("p3").transform;
    [Range(0, 1), SerializeField] protected float t;
    protected float colectibleSpeed = 0.1f;
    [SerializeField] protected AnimationCurve collectibleSpeedCurve;
    protected Vector3 p4;
    public static event Action addColectible;
    protected Vector3 scaleOfCollectible
    {
        get => this.transform.localScale;
        set => this.transform.localScale = value;
    }

    protected virtual void OnEnable()
    {
        var mainCamera = Camera.main;
        p1 = this.transform.position;
    }
    protected virtual void FixedUpdate(){}

    protected void SpeedCalculating()
    {
        if (t < 1)
            t += collectibleSpeedCurve.Evaluate(colectibleSpeed);
        else
        {
            addColectible?.Invoke();
            t = 0f;
            gameObject.SetActive(false);
        }
    }
}