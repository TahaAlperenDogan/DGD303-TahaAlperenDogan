using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject projectilePrefab; // Mermi prefab referans�
    public Transform[] firePoints;      // Birden fazla ate� noktas�
    public float projectileSpeed = 10f; // Mermi h�z�
    public float fireRate = 1f;         // Ate� etme s�kl��� (saniye cinsinden)

    private int currentFirePointIndex = 0; // S�radaki ate� noktas�
    private float nextFireTime;            // Bir sonraki ate� zaman�

    void Update()
    {
        // Ate� etme kontrol� (s�rekli ate�)
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Bir sonraki ate� zaman�n� ayarla
        }
    }

    void Shoot()
    {
        // �u anki ate� noktas�ndan mermiyi olu�tur
        Transform firePoint = firePoints[currentFirePointIndex];
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Mermiye h�z ekle
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.down * projectileSpeed; // Mermiyi a�a�� do�ru hareket ettir
        }

        // S�radaki ate� noktas�na ge�
        currentFirePointIndex++;
        if (currentFirePointIndex >= firePoints.Length)
        {
            currentFirePointIndex = 0; // D�ng�y� s�f�rla
        }
    }
}
