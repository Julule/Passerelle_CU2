
using UnityEngine;
using UnityEngine.AI;

public class MoveOnTrigger : MonoBehaviour
{
    public enum MoveDirection { up, right, forward, down, left, back }

    [SerializeField] private MoveDirection moveDirection = MoveDirection.up;
    [field: SerializeField] public float TimeToMove { get; private set; } = 1f;

    [Tooltip(" Distance between start and end position.")]
    [SerializeField] private float distance = 1f;

    private Vector3 startPosition;
    private Vector3 endPosition;

    private float chrono = 0f;
    private bool isActived = false;

    private Transform target;

    private void Start()
    {
        NavMeshObstacle obstacle = GetComponentInChildren<NavMeshObstacle>();

        if(obstacle == null) // diff. de isNull !
        {
            Debug.LogError("You need to have children with a NavMeshObstacle !");   
        }

        target = obstacle.transform;

        
        chrono = TimeToMove;
        startPosition = target.position;
        Vector3 direction = Vector3.zero;
        switch (moveDirection)
        {
            case MoveDirection.up: direction = Vector3.up; break;
            case MoveDirection.right: direction = Vector3.right; break;
            case MoveDirection.forward: direction = Vector3.forward; break;
            case MoveDirection.down: direction = Vector3.down; break;
            case MoveDirection.left: direction = Vector3.left; break;
            case MoveDirection.back: direction = Vector3.back; break;
        }

        endPosition = startPosition + direction * distance;

    }

    private void Update()
    {
        chrono += Time.deltaTime;
        float progression = chrono / TimeToMove;
        if (!isActived) 
        {
            target.position = Vector3.Lerp(endPosition, startPosition, progression);
   
        }
        else
        {
            target.position = Vector3.Lerp(startPosition, endPosition, progression);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        isActived = true;
        chrono = 0f;
    }

    void OnTriggerExit(Collider other)
    {
        isActived = false;
        chrono = 0f;
    }

}

 