using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedHihlightState : State
{
    
    public RedHihlightState(AvalableToBuildGround tower, TowerStateMachine stateMachine) : base(tower,stateMachine)
    {
        
    }
    public override void Enter()
    {
        base.Enter();
        Tower.ChangeRenderingMode(Tower.allMaterials,Tower.HighlightedRed.color);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(Tower.detectedGround)
        {
            stateMachine.ChangeState(Tower.greened);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
