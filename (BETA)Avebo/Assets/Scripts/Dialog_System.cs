using UnityEngine;

public class SpriteHealthListener : MonoBehaviour
{
    public BossHealth bossHealth; // Takip edilecek boss'un saðlýk scripti
    public SpriteRenderer spriteRenderer; // Bu scriptin kontrol edeceði sprite renderer

    void Start()
    {
        // Eðer spriteRenderer atanmamýþsa, mevcut GameObject'ten alýnýr
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // BossHealth referansý atanmýþ mý kontrol et
        if (bossHealth == null)
        {
            Debug.LogError("BossHealth referansý atanmadý!");
        }
    }

    void Update()
    {
        if (bossHealth != null)
        {
            UpdateSpriteVisibility();
        }
    }

    void UpdateSpriteVisibility()
    {
        // Eðer boss saðlýðý %50'nin altýndaysa sprite görünür olur
        if (bossHealth.currentHealth <= bossHealth.maxHealth / 2)
        {
            spriteRenderer.enabled = true; // Sprite'ý görünür yap
        }
        else
        {
            spriteRenderer.enabled = false; // Sprite'ý gizle
        }
    }
}
