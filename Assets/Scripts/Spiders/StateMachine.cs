using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    protected IStateful State;

    public void SetState(IStateful state)
    {
        State = state;
        StartCoroutine(state.Start());
    }
}