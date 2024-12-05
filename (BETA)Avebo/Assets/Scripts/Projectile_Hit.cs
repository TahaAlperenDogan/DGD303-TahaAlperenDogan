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
        }

        // Eðer baþka bir þeyle çarpýþýrsa
        if (collision.tag == "Obstacle")
        {
            Destroy(gameObject); // Mermiyi yok et
        }
    }
}
