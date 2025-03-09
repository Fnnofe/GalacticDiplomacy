using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityMover : MonoBehaviour
{
    private NavMeshAgent agent;
    private StateMachine stateMachine;
    public List<Transform> waypoints; // Assign in Unity Editor

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = gameObject.AddComponent<StateMachine>();
        stateMachine.ChangeState(new Patrol(stateMachine, agent, waypoints));
    }

    void Update()
    {
        stateMachine.Update();
    }
}
