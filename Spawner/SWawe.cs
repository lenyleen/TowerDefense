using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SWawe : AbstractWawe
{
    public SWawe(EnemySpawn spawn, SpawnStateMachine stateMachine, GameObject UFO) : base(spawn, stateMachine, UFO)
    {
        
    }
    public override void Enter()
    {
        var enemySpawner = GameObject.FindGameObjectWithTag("Spawner2").transform;
        var enemySpawnerPosition = enemySpawner.position;
        base.Enter();
        spawn.spawnPositions.Add(enemySpawner);
        spawn.alertFade.transform.position = new Vector3(enemySpawnerPosition.x, 0.1f, enemySpawnerPosition.z); 
        spawn.alertFade.SetActive(true);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (spawn.UFOcount.Capacity <= 10) return;
        stateMachine.ChangeState(spawn.tw);
    }
    

    public override void Exit()
    {
        spawn.delayOfSpawn = 4f;
      base.Exit();  
    }
}
