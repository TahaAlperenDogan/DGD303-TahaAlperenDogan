using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Mermi prefab referansý
    public Transform[] firePoints;      // Birden fazla ateþ noktasý
    public float projectileSpeed = 10f; // Mermi hýzý
    public float fireRate = 1f;         // Ateþ etme sýklýðý (saniye cinsinden)

    private int currentFirePointIndex = 0; // Sýradaki ateþ noktasý
    private float nextFireTime;            // Bir sonraki ateþ zamaný

    void Update()
    {
        // Ateþ etme kontrolü (sürekli ateþ)
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Bir sonraki ateþ zamanýný ayarla
        }
    }

    void Shoot()
    {
        // Þu anki ateþ noktasýndan mermiyi oluþtur
        Transform firePoint = firePoints[currentFirePointIndex];
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Mermiye hýz ekle
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * projectileSpeed; // Mermiyi aþaðý doðru hareket ettir
        }

        // Sýradaki ateþ noktasýna geç
        currentFirePointIndex++;
        if (currentFirePointIndex >= firePoints.Length)
        {
            currentFirePointIndex = 0; // Döngüyü sýfýrla
        }
    }
}
