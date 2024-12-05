using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 10; // Mermi hasar de�eri

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Boss'a �arparsa
        BossHealth boss = collision.GetComponent<BossHealth>();
        if (boss != null)
        {
            boss.TakeDamage(damage); // Boss'a hasar ver
            Destroy(gameObject);    // Mermiyi yok et
            return; // Di�er kontrolleri atlar
        }

        // Player'a �arparsa
        PlayerHealth player = collision.GetComponent<PlayerHealth>();
        if (player != null)
        {
            player.TakeDamage(damage); // Player'�n can�n� azalt
            Destroy(gameObject);       // Mermiyi yok et
            return; // Di�er kontrolleri atlar
        }

        // E�er bir engelle �arp���rsa
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
