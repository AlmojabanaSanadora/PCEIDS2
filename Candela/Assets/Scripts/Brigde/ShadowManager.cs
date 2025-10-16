using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShadowManager : MonoBehaviour
{
    public float radius = 10f;
    [Range(0, 360)]
    public float angle = 90f;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;


    NavMeshAgent agent;
    public float patrolWaitTime = 2f;

    public Transform patrols;
    private bool isPatrolling = false;
    private Coroutine patrolCoroutine;
    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }

    private void Update()
    {
        if (canSeePlayer)
        {
            if (isPatrolling)
            {
                StopCoroutine(Patrols());
                isPatrolling = false;
            }

            agent.SetDestination(playerRef.transform.position);
        }
        else
        {
            if(!isPatrolling)
            {
                StartCoroutine(Patrols());
            }

        }
    }
    
    private IEnumerator Patrols()
    {
        isPatrolling = true;
        agent.ResetPath();
        while (isPatrolling)
        {
            Transform currentPatrol = patrols.GetChild(UnityEngine.Random.Range(0, patrols.childCount));
            agent.SetDestination(currentPatrol.position);

            yield return new WaitUntil(() => !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.1f);

            yield return new WaitForSeconds(patrolWaitTime);
        }

    }
}