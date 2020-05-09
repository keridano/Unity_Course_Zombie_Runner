using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity; //we want the enemy to chase target only when needed

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        if(distanceToTarget <= chaseRange)
            navMeshAgent.SetDestination(target.position);
    }
}
