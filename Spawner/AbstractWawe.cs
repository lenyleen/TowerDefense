using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static System.Threading.Thread;

public abstract class AbstractWawe
{
    protected EnemySpawn spawn;
    protected SpawnStateMachine stateMachine;
    public Action waveAction;
    protected GameObject UFO;
    protected AbstractWawe(EnemySpawn spawn, SpawnStateMachine stateMachine, GameObject UFO)
    {
        this.spawn = spawn;
        this.stateMachine = stateMachine;
        this.UFO = UFO;
    }
    public virtual void Enter()
    {
        spawn.UFOcount = new List<GameObject>();
        spawn.StartCoroutine(spawn.SpawnFWave());
    }
    public virtual void LogicUpdate()
    {

    }
    public virtual void Exit()
    {
        spawn.StopAllCoroutines();
        Task.Run(() => Sleep(7000));
    }
 }
