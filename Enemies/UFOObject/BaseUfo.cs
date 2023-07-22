using System;
using UnityEngine;

public class BaseUfo : MonoBehaviour
{
    public delegate void KickDelegate();
    public KickDelegate kick;
    public int hp;
    public int maxHp;
    public StateMachine sm = new StateMachine();
    public NofmalState ns;
    public SmokingState smoke;
    public OnDestroyingState onDest;
    public static event Action ufoAction;
    public GameObject particles => this.transform.GetChild(0).gameObject;
    [SerializeField] public GameObject Explosion;
    protected virtual void Start()
    {
        Explosion.SetActive(false);
        ns = new NofmalState(this, sm);
        smoke = new SmokingState(this, sm);
        onDest = new OnDestroyingState(this, sm);
        sm.Initialize(ns);
    }

    protected virtual void FixedUpdate()
    {
        sm.CurrentState.PhysicUpdate();
    }

    protected virtual void Update()
    {
        sm.CurrentState.LogicUpdate();
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (hp < 0) 
            kick?.Invoke();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        sm.ChangeState(ns);
        hp = 4;
        ufoAction?.Invoke();
        this.transform.parent.gameObject.SetActive(false);
    }
}



