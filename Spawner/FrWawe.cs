using UnityEngine;

public class FrWawe : AbstractWawe
{
    public FrWawe(EnemySpawn spawn, SpawnStateMachine stateMachine, GameObject UFO) : base(spawn, stateMachine, UFO)
    {
        
    }
    public override void Enter()
    {
        var enemySpawner = GameObject.FindGameObjectWithTag("Spawner4").transform;
        var enemySpawnerPosition = enemySpawner.position;
        base.Enter();
        spawn.ufoFabric = SingletonHardUFOs.instance;
        spawn.spawnPositions.Add(enemySpawner);
        spawn.alertFade.transform.position = new Vector3(enemySpawnerPosition.x, 0.1f, enemySpawnerPosition.z); 
        spawn.alertFade.SetActive(true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (spawn.UFOcount.Capacity <= 20) return;
        waveAction?.Invoke();
        stateMachine.ChangeState(spawn.endState);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
