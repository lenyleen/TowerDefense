using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected AvalableToBuildGround Tower;
    protected TowerStateMachine stateMachine;
    protected State(AvalableToBuildGround tower, TowerStateMachine stateMachine)
    {
        this.Tower = tower;
        this.stateMachine = stateMachine;
    }
    public virtual void Enter()
    {
        
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {

    }
}
