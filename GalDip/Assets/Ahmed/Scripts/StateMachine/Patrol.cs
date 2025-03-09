using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{

    private NavMeshAgent nav;
    private List<Transform> waypoints;
    private int currentWaypointIndex = 0;

    public Patrol(StateMachine stateMachine, NavMeshAgent nav, List<Transform> waypoints) : base(stateMachine)
    {
        this.nav = nav;
        this.waypoints = waypoints;
    }

    public override void Enter()
    {
        Debug.Log("Patrol Enter");
    }

    public override void Update()
    {
        if (waypoints.Count == 0) return;
        
        Transform waypoint = waypoints[currentWaypointIndex];
        nav.SetDestination(waypoint.position);
        Debug.Log("Patrol Update");

        if (Vector3.Distance(nav.transform.position, waypoint.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
        }
    }

    public override void Exit()
    {
        Debug.Log("Patrol Exit");
    }
}
