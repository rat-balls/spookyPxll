using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ChasingAI : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent enemy;
    private Raycasting raycaster;

    public float maxSightDistance;
    public int sightIterations;
    private float fleetingTimer = 0;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        raycaster = GetComponent<Raycasting>();
    }

    // Update is called once per frame
    void Update()
    {

        enemy.SetDestination(player.position);
        transform.LookAt(player.transform);

        float distance = Vector3.Distance(transform.position, player.position);



        if (raycaster.CanSeePlayer(maxSightDistance, sightIterations))
        {
            if (distance <= 1)
            {
                Debug.Log("T mor");
            }
        }
        else
        {
            fleetingTimer += Time.deltaTime;
            if (fleetingTimer >= 3)
            {
                fleetingTimer = 0;
                enabled = false;
                GetComponent<WonderAI>().enabled = true;
                enemy.SetDestination(transform.position);
            }
        }
        


    }
}