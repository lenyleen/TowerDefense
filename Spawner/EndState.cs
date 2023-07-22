using UnityEngine;

public class EndState : AbstractWawe
{
    public EndState(EnemySpawn spawn, SpawnStateMachine stateMachine, GameObject UFO) : base(spawn, stateMachine, UFO)
    {
    }

    public override void Enter()
    {
        spawn.StopAllCoroutines();
    }
}
