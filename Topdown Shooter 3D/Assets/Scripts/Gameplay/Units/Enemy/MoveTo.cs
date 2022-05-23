using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveTo : MonoBehaviour
{
    public Transform goal;

    private NavMeshAgent agent;
       
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetGoal(Transform newGoal)
    {
        goal = newGoal;
    }

    private void UpdateTarget()
    {
        if (agent.enabled)
        {
            agent.destination = goal.position;
        }
    }

    private void Update()
    {
        if (goal != null)
            UpdateTarget();
    }
}
