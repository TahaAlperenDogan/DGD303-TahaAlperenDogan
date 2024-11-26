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
        }

        // E�er ba�ka bir �eyle �arp���rsa
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
