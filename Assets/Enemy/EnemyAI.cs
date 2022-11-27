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
 
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, this.transform.position);

        if (distanceToTarget < chaseRange)
        {
            navMeshAgent.SetDestination(target.position);     
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
