using UnityEngine;
public class Move : MonoBehaviour{
    public enum MoveDirection { up, right, forward, down, left, back }

    [SerializeField] private MoveDirection moveDirection = MoveDirection.up;
    [SerializeField] private float time = 1f;
    [Tooltip("Distance between start and end position.")] // Tooltip affiche un message quand on place la souris sur la variable dans Unity. Doit être écrit AVANT la variable. 
    [SerializeField] private float distance = 1f;
    private Vector3 startPosition;
    private Vector3 endPosition;

    private float chrono = 0f;

    private void Start()
    {

        startPosition = transform.position;
        Vector3 direction = Vector3.zero;
        switch(moveDirection)
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
        float progression = chrono / time;
        transform.position = Vector3.Lerp(startPosition, endPosition, progression);
    }

}
 