using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TWawe : AbstractWawe
{
    public TWawe(EnemySpawn spawn, SpawnStateMachine stateMachine, GameObject UFO) : base(spawn, stateMachine, UFO)
    {
        
    }
    public override void Enter()
    {
        var enemySpawner = GameObject.FindGameObjectWithTag("Spawner3").transform;
        var enemySpawnerPosition = enemySpawner.position;
        base.Enter();
        spawn.spawnPositions.Add(enemySpawner);
        spawn.alertFade.transform.position = new Vector3(enemySpawnerPosition.x, 0.1f, enemySpawnerPosition.z); 
        spawn.alertFade.SetActive(true);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (spawn.UFOcount.Capacity <= 15) return;
        stateMachine.ChangeState(spawn.frW);
        
    }
    public override void Exit()
    {
        spawn.delayOfSpawn = 3f;
        base.Exit();
    }
}
