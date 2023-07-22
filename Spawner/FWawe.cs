using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class FWawe : AbstractWawe
{
    public FWawe(EnemySpawn spawn, SpawnStateMachine stateMachine, GameObject UFO) : base(spawn, stateMachine, UFO)
    {

    }
    public override void Enter()
    {
        var enemySpawner = GameObject.FindGameObjectWithTag("Spawner1").transform;
        var enemySpawnerPosition = enemySpawner.position;
        base.Enter();
        spawn.ufoFabric = SingletonUFOs.instance;
        spawn.spawnPositions.Add(enemySpawner);
        spawn.alertFade.transform.position = new Vector3(enemySpawnerPosition.x, 0.1f, enemySpawnerPosition.z); 
        spawn.alertFade.SetActive(true);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (spawn.UFOcount.Capacity <= 5) return;
        stateMachine.ChangeState(spawn.sw);
    }
    public override void Exit()
    { 
        base.Exit();
    }
    
}
