using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    public Transform healthBar; // Can barýný temsil eden GameObject'in Transform'u
    public BossHealth bossHealth; // Boss'un health script'i
    

    public Vector3 originalScale; // Baþlangýçtaki boyut

    void Start()
    {
        if (healthBar == null)
        {
            Debug.LogError("Health Bar Transform is not assigned!");
        }

        // Can barýnýn baþlangýç boyutunu kaydet
        originalScale = healthBar.localScale;
    }

    void Update()
    {
        // Boss'un mevcut canýný al ve barý ölçekle
        float healthPercent = (float)bossHealth.currentHealth / bossHealth.maxHealth;
        healthBar.localScale = new Vector3(originalScale.x * healthPercent, originalScale.y, originalScale.z);
    }
}
