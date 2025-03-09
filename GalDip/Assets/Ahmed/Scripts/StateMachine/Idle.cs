using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Idle(StateMachine stateMachine) : base(stateMachine) {}
    public override void Enter()
    {
        Debug.Log("Entered Idle State");
    }

  

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}
