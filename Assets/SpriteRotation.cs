using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    // The original scale of the sprite
    private Vector3 originalScale = new Vector3(0.2f, 0.2f, 1f);

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>(); // Get the PlayerMovement component
        // Set the original scale
        transform.localScale = originalScale;
    }

    private void Update()
    {
        RotateSprite(); // Call the rotation function in each frame
    }

    private void RotateSprite()
    {
        // Check for horizontal movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Debugging log for horizontal input
        Debug.Log("Horizontal Input: " + moveHorizontal);

        if (moveHorizontal < 0) // Moving right
        {
            // Face right
            transform.localScale = new Vector3(originalScale.x, originalScale.y, originalScale.z); // Maintain original scale (facing right)
        }
        else if (moveHorizontal > 0) // Moving left
        {
            // Face left
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z); // Invert scale on the x-axis (facing left)
        }
    }
}
