using System.Collections;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    public GameObject fallingObjectPrefab; // The prefab to instantiate
    public float spawnInterval; // Time between spawns
    private Health playerHealth; // Reference to the player's Health

    private void Start()
    {
        // Ensure playerHealth is set correctly by finding the Health script on the player
        playerHealth = FindObjectOfType<Health>();  // Find the player's health script in the scene
        if (playerHealth == null)
        {
            Debug.LogError("Player's Health script not found in the scene!");
            return;
        }

        // Start the spawning coroutine
        StartCoroutine(SpawnFallingObjects());
    }

    private IEnumerator SpawnFallingObjects()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }

    private void SpawnObject()
    {
        // Randomize the spawn position along the x-axis
        float randomX = Random.Range(-10f, 10f); // Adjust range based on your camera view
        Vector3 spawnPosition = new Vector3(randomX, 10f, 0); // Spawn above the screen (y = 10)

        // Instantiate the falling object at the spawn position
        GameObject newFallingObject = Instantiate(fallingObjectPrefab, spawnPosition, Quaternion.identity);
        Debug.Log("Falling object spawned at: " + spawnPosition);

        // Initialize the FallingObject with the player's Health reference
        newFallingObject.GetComponent<FallingObject>().Initialize(playerHealth);
        
        // Start the coroutine to destroy the object after 10 seconds
        StartCoroutine(DestroyAfterTime(newFallingObject, 10f));
    }

    private IEnumerator DestroyAfterTime(GameObject objectToDestroy, float time)
    {
        yield return new WaitForSeconds(time); // Wait for the specified amount of time
        Destroy(objectToDestroy); // Destroy the falling object
    }
}
