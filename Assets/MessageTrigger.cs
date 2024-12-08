using System.Collections;
using UnityEngine;

public class MessageTrigger : MonoBehaviour
{
    public GameObject messagePopup; // Reference to the popup UI element
    public float displayTime = 3f;  // Time to show the message

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger zone!"); // Debugging message
            StartCoroutine(ShowMessage());
        }
    }

    private IEnumerator ShowMessage()
    {
        messagePopup.SetActive(true);           // Show the popup
        yield return new WaitForSeconds(displayTime); // Wait for the specified time
        messagePopup.SetActive(false);         // Hide the popup
    }
}
