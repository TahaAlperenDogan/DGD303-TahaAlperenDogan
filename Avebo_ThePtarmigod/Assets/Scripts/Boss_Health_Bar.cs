using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public Transform healthBar; // Can bar�n� temsil eden GameObject'in Transform'u
    public BossHealth bossHealth; // Boss'un health script'i
    

    public Vector3 originalScale; // Ba�lang��taki boyut

    void Start()
    {
        if (healthBar == null)
        {
            Debug.LogError("Health Bar Transform is not assigned!");
        }

        // Can bar�n�n ba�lang�� boyutunu kaydet
        originalScale = healthBar.localScale;
    }

    void Update()
    {
        // Boss'un mevcut can�n� al ve bar� �l�ekle
        float healthPercent = (float)bossHealth.currentHealth / bossHealth.maxHealth;
        healthBar.localScale = new Vector3(originalScale.x * healthPercent, originalScale.y, originalScale.z);
    }
}
