using System;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;

public class GreenHighlightState : State
{
    public delegate void Drop();

    public static Drop drop;
    public GreenHighlightState(AvalableToBuildGround tower, TowerStateMachine stateMachine) : base(tower,stateMachine)
    {
        this.Tower = tower;
        Tower.drop += ChangeToDropped;
    }
    public override void Enter()
    {
        base.Enter();
        Tower.ChangeRenderingMode(Tower.allMaterials,Tower.HighlightedGreen.color);
    }
    public override void LogicUpdate()
    {}
    private void ChangeToDropped()
    {
        if(Tower != null)
            drop?.Invoke();
        Tower.transform.position = new Vector3(Tower.transform.position.x,0.2f,Tower.transform.position.z);
        stateMachine.ChangeState(Tower.dropped);
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if(!Tower.detectedGround)
        {
            stateMachine.ChangeState(Tower.reded);
        }
    }
    
}
