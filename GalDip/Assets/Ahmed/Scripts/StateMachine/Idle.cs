using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(StateMachine stateMachine) : base(stateMachine) {}
    public override IEnumerator Enter()
    {
        Debug.Log("Entered Idle State");
        //stateMachine.ChangeState();
        yield return null;
    }

  

    public override IEnumerator Exit()
    {
        Debug.Log("Exiting Idle State");
        yield return null;
    }
}
