using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //we want the enemy to chase target only when needed

    bool isProvoked;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (isProvoked)
            EngageTarget();
        else if(distanceToTarget <= chaseRange)
            isProvoked = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    private void EngageTarget()
    {
        if (distanceToTarget > navMeshAgent.stoppingDistance)
            ChaseTarget();
        else//if (distanceToTarget <= navMeshAgent.stoppingDistance)
            AttackTarget();
    }

    private void ChaseTarget()
    {
        navMeshAgent.SetDestination(target.position);
    }

    private void AttackTarget()
    {
        Debug.Log($"{name} Attack {target.name}");
    }
}
