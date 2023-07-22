using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class OnDestroyingState : AbstractUfo
{
    private GameObject particles => main.transform.parent.GetChild(0).gameObject;
    public OnDestroyingState (BaseUfo main, StateMachine stateMachine) : base(main,stateMachine)
    {
       
    }
    public override void Enter()
    {
        base.Enter();
        Explode();
    }

    private async void Explode()
    {
        var coin = SingletonUFOs.instance.GetCoin(main.transform);
        coin.SetActive(true);
        main.Explosion.SetActive(true);
        main.gameObject.SetActive(false);
        await Task.Delay(1000);
        ufoAction?.Invoke(main);
        main.Explosion.SetActive(false);
        main.particles.SetActive(false);
        main.transform.parent.gameObject.SetActive(false);
        stateMachine.ChangeState(main.ns);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
