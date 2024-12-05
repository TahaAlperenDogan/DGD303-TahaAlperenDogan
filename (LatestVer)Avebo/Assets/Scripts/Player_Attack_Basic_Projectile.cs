using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    public Transform firePoint;         // Position where projectiles are spawned
    public float projectileSpeed = 10f; // Speed of the projectiles

    void Update()
    {
        // Check if the "K" key is pressed
        if (Input.GetKeyDown(KeyCode.K))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the firePoint position
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Add velocity to the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.up * projectileSpeed; // Move the projectile upward
        }
    }
}
