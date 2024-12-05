using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the boss
    public float changeInterval = 2f; // Time interval between direction changes
    public Vector2 minBounds = new Vector2(-5f, -5f); // Minimum bounds (x, y)
    public Vector2 maxBounds = new Vector2(5f, 5f);  // Maximum bounds (x, y)

    private Vector2 targetPosition; // The target position for movement
    private float timeToChange; // Timer for movement change

    void Start()
    {
        // Initial target position
        timeToChange = changeInterval;
        SetNewTargetPosition();
    }

    void Update()
    {
        // Decrease the timer by time passed each frame
        timeToChange -= Time.deltaTime;

        // If the timer hits zero, change the direction
        if (timeToChange <= 0f)
        {
            SetNewTargetPosition();
            timeToChange = changeInterval; // Reset the timer
        }

        // Move the boss towards the target position
        MoveToTarget();
    }

    void SetNewTargetPosition()
    {
        // Set a random target within the specified bounds
        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomY = Random.Range(minBounds.y, maxBounds.y);
        targetPosition = new Vector2(randomX, randomY);
    }

    void MoveToTarget()
    {
        // Move the boss towards the target position using the speed factor
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Clamp the boss's position within the specified bounds
        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(transform.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(transform.position.y, minBounds.y, maxBounds.y)
        );

        transform.position = clampedPosition;
    }
}
