using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10; // Mermi hasar deðeri

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Boss'a çarparsa
        BossHealth boss = collision.GetComponent<BossHealth>();
        if (boss != null)
        {
            boss.TakeDamage(damage); // Boss'a hasar ver
            Destroy(gameObject);    // Mermiyi yok et
            return; // Diðer kontrolleri atlar
        }

        // Player'a çarparsa
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage); // Player'ýn canýný azalt
            Destroy(gameObject);       // Mermiyi yok et
            return; // Diðer kontrolleri atlar
        }

        // Eðer bir engelle çarpýþýrsa
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
