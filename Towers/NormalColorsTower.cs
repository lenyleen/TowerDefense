using UnityEngine;

public class NormalColorsTowerState : State
{
   public NormalColorsTowerState(AvalableToBuildGround tower, TowerStateMachine stateMachine) : base(tower,stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        Tower.ChangeRenderingMode(Tower.allMaterials,Tower.col);
        Tower.GetComponent<BoxCollider>().enabled = false;
        Tower.GetComponent<AvalableToBuildGround>().enabled = false;
    }
}
