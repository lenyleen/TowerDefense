using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokingState : AbstractUfo
{
    public SmokingState (BaseUfo main, StateMachine stateMachine) : base(main,stateMachine)
    {
       
    }
    public override void Enter()
    {
        base.Enter();
        main.hp = main.maxHp/2;
        main.kick = HPCeheck;
        main.particles.SetActive(true);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }
    private void HPCeheck()
    {
        main.hp--;
        if(main.hp > 0) return;
        stateMachine.ChangeState(main.onDest);
    }
}
