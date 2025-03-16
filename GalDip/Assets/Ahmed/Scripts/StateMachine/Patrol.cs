using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    private int currentWaypointIndex = 0;

    public Patrol(StateMachine stateMachine) : base(stateMachine)
    {
    }

    public override IEnumerator Enter()
    {
        if (stateMachine.waypoints.Count > 0)
        {
            stateMachine.agent.SetDestination(stateMachine.waypoints[currentWaypointIndex].position);
        }
        yield return null;
    }

    public override IEnumerator Update()
    {
        if (stateMachine.waypoints.Count == 0) yield return null;
        
        Transform waypoint = stateMachine.waypoints[currentWaypointIndex];
        stateMachine.agent.SetDestination(waypoint.position);
        //Debug.Log("Patrol Update");

        if (Vector3.Distance( stateMachine.agent.transform.position, waypoint.position) < 3f)
        {
            Debug.Log("Destination Reached");
            currentWaypointIndex = currentWaypointIndex + 1;
        }
        yield return null;
    }

    public override IEnumerator Exit()
    {
        Debug.Log("Patrol Exit");
        yield return null;
    }
}
