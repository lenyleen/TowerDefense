using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NofmalState : AbstractUfo
{
    public NofmalState (BaseUfo main, StateMachine stateMachine) : base(main,stateMachine)
    {
       
    }
    public override void Enter()
    {
        base.Enter();
        main.hp = main.maxHp;
        main.particles.SetActive(false);
        main.gameObject.SetActive(true);
        main.kick = HpCheck;
    }
    private void HpCheck()
    {
        main.hp--;
        if(main.hp > 0) return;
        stateMachine.ChangeState(main.smoke);
    }
}
