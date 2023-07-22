using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SpawnStateMachine
{
    public AbstractWawe CurrentState { get; private set; }
    public void Initialize(AbstractWawe startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }
    public void ChangeState(AbstractWawe newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
