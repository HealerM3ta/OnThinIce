using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // Reference to the player’s transform
    public float smoothSpeed; // Smooth factor for the camera movement
    public Vector3 offset;            // Offset of the camera from the player

    public float screenLeftBound; // Adjusted screen boundary on the left
    public float screenRightBound; // Adjusted screen boundary on the right


    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(player.position);

        // Check if the player is within the right screen boundary
        if (screenPoint.x > screenRightBound)
        {
            // Calculate the new position with an offset
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        // Optionally, check the left screen boundary for backtracking
        else if (screenPoint.x < screenLeftBound)
        {
            Vector3 desiredPosition = new Vector3(player.position.x - offset.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
