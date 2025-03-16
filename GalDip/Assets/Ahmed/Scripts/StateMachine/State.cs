using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected StateMachine stateMachine;

    public State(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public virtual IEnumerator Enter()
    {
        yield break;
    }

    public virtual IEnumerator Update()
    {
        yield break;
    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
