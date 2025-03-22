using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachine : MonoBehaviour
{
    protected State CurrentState;
    
    public NavMeshAgent agent;
    public List<Transform> waypoints;

    public void ChangeState(State newState)
    {
        if (CurrentState != null)
        {
            StartCoroutine(CurrentState.Exit());
        }

        CurrentState = newState;
    
        if (CurrentState != null)
        {
            StartCoroutine(CurrentState.Enter());
        }
    }
    private void Start()
    {
        ChangeState(new Patrol(this));
    }
    private void Update()
    {
        if (CurrentState != null)
        {
            StartCoroutine(CurrentState.Update());
        }
    }
}
