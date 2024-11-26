using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the boss
    public float changeInterval = 2f; // Time interval between direction changes
    public Vector2 minMovement = new Vector2(-5f, -5f); // Min movement bounds (x, y)
    public Vector2 maxMovement = new Vector2(5f, 5f);  // Max movement bounds (x, y)

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
        // Set a random target within specified bounds
        float randomX = Random.Range(minMovement.x, maxMovement.x);
        float randomY = Random.Range(minMovement.y, maxMovement.y);
        targetPosition = new Vector2(randomX, randomY);
    }

    void MoveToTarget()
    {
        // Move the boss towards the target position using the speed factor
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
