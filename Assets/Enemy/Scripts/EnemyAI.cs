using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject target;
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
        distanceToTarget = Vector3.Distance(target.transform.position, this.transform.position);

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
        GetComponent<Animator>().SetBool("attack",false);
        GetComponent<Animator>().SetTrigger("move");
        navMeshAgent.SetDestination(target.transform.position);
    }

    void AttackTarget()
    {
        GetComponent<Animator>().SetBool("attack",true);
        Debug.Log("Attack!!");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
