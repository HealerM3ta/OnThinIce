using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance;  // Distance to move in each direction
    public float moveSpeed;     // Speed of movement

    private Vector3 startPosition;
    private Vector3 targetPosition;
    void Start()
    {
        // Save the initial position of the platform
        startPosition = transform.position;
        targetPosition = startPosition + new Vector3(moveDistance, 0f, 0f);  // Set the target position
    }

    void Update()
    {
        // Move platform left and right using Mathf.PingPong
        float pingPong = Mathf.PingPong(Time.time * moveSpeed, moveDistance); // Moves between 0 and moveDistance
        transform.position = startPosition + new Vector3(pingPong, 0f, 0f); // Update platform position
    }
}
