using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public AbstractUfo CurrentState { get; private set; }
    public void Initialize(AbstractUfo startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }
    public void ChangeState(AbstractUfo newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        newState.Enter();
    }
}
