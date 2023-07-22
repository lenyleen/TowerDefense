using System;
using UnityEngine;

public abstract class AbstractUfo
{
    protected StateMachine stateMachine;
    protected BaseUfo main;
    public Action<BaseUfo> ufoAction;
    protected AbstractUfo(BaseUfo main, StateMachine stateMachine)
    {
        this.main = main;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
    }
    public virtual void LogicUpdate()
    {
    }
    public virtual void PhysicUpdate()
    {
        main.transform.eulerAngles += Vector3.up * 2;
    }
    public virtual void Exit()
    {
        main.kick = null;
    }
}
