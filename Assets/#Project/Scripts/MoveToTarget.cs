using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Renderer))]
public class MoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 startPosition;
    private bool isWayBack = false;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.position);
        startPosition = transform.position;

    }


    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            if (isWayBack)
            {
                agent.SetDestination(target.position);
                GetComponent<Renderer>().material.color = Color.red;
                agent.avoidancePriority = Random.Range(50, 100);
            }
            else
            {
                GetComponent<Renderer>().material.color = Color.cyan;
                agent.SetDestination(startPosition);
                agent.avoidancePriority = Random.Range(1, 49);
            }
            isWayBack = !isWayBack;
        }
    }
}
