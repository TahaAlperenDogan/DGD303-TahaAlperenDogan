using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of the player movement

    void Update()
    {
        // Get input from WASD or arrow keys
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right arrows
        float moveVertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down arrows

        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0).normalized;

        // Move the player
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
