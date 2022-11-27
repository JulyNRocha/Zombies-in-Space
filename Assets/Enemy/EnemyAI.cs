using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;

    float distanceToTarget = Mathf.Infinity;
    NavMeshAgent navMeshAgent;
    bool isProvoked = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);

        if(isProvoked)
        {
            EngageTarget();
        }
        
        if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }
    }

    void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        else if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    void AttackTarget()
    {
        Debug.Log("Attack!!");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
