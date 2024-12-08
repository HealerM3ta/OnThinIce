using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          // Reference to the player’s transform
    public float smoothSpeed;         // Smooth factor for the camera movement
    public Vector3 offset;            // Offset of the camera from the player

    public float screenLeftBound;     // Adjusted screen boundary on the left
    public float screenRightBound;    // Adjusted screen boundary on the right
    public float screenTopBound;      // Adjusted screen boundary on the top
    public float screenBottomBound;   // Adjusted screen boundary on the bottom

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        Vector3 screenPoint = cam.WorldToViewportPoint(player.position);

        // Horizontal movement - checking left and right screen bounds
        if (screenPoint.x > screenRightBound)
        {
            // Calculate the new position with an offset for right movement
            Vector3 desiredPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
        else if (screenPoint.x < screenLeftBound)
        {
            // Calculate the new position with an offset for left movement
            Vector3 desiredPosition = new Vector3(player.position.x - offset.x, transform.position.y, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

        // // Vertical movement - only move if player is outside top or bottom screen bounds
        // if (screenPoint.y > screenTopBound)
        // {
        //     // Move the camera instantly to the new position above the player
        //     transform.position = new Vector3(transform.position.x, player.position.y + offset.y, transform.position.z);
        // }
        // else if (screenPoint.y < screenBottomBound)
        // {
        //     // Move the camera instantly to the new position below the player
        //     transform.position = new Vector3(transform.position.x, player.position.y - offset.y, transform.position.z);
        // }

    }
}
