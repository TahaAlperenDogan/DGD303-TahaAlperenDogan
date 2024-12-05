using UnityEngine;

public class BackgroundLooper : MonoBehaviour
{
    public float speed = 2f; // Speed of the background movement
    public float resetPosition = -10f; // Position where the background resets
    public float startPosition = 10f; // Starting position after reset

    void Update()
    {
        // Move the background down
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Check if the background has moved past the reset position
        if (transform.position.y <= resetPosition)
        {
            // Reset the position
            transform.position = new Vector3(transform.position.x, startPosition, transform.position.z);
        }
    }
}
