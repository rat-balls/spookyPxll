using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public float startWaitTime = 0f;
    public float timeToRotate = 2f;
    public float speedWalk = 3f;
    private Raycasting raycaster;

    public float maxSightDistance;
    public int sightIterations;

    public Transform[] waypoints;


    float m_WaitTime;
    int m_CurrentWaypointIndex;
    float m_TimeToRotate;
    void Start()
    {
        raycaster = GetComponent<Raycasting>();
        m_WaitTime = startWaitTime;
        m_TimeToRotate = timeToRotate;

        m_CurrentWaypointIndex = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = speedWalk;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
    private void Patroling()
    {
        if (m_TimeToRotate <= 0)
        {
            Move(speedWalk);

        }
        else
        {
            Stop();
            m_TimeToRotate -= Time.deltaTime;
        }
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (m_WaitTime <= 0)
            {
                NextPoint();
                Move(speedWalk);
                m_WaitTime = startWaitTime;
            }
            else
            {
                Stop();
                m_WaitTime -= Time.deltaTime;
            }
        }
    }

    private void Move(float speed)
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.speed = speed;
    }
    private void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.speed = 0;
    }
    public void NextPoint()
    {
        m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
        navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
    }
    void Update()
    {
        Patroling();
        if (raycaster.CanSeePlayer(maxSightDistance, sightIterations))
        {
            enabled = false;
            GetComponent<LookingAI>().enabled = true;
        }
    }
}

