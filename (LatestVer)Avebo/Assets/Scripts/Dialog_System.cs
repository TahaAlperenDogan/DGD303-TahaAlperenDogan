using UnityEngine;

public class SpriteHealthListener : MonoBehaviour
{
    public BossHealth bossHealth; // Takip edilecek boss'un sa�l�k scripti
    public SpriteRenderer spriteRenderer; // Bu scriptin kontrol edece�i sprite renderer

    void Start()
    {
        // E�er spriteRenderer atanmam��sa, mevcut GameObject'ten al�n�r
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // BossHealth referans� atanm�� m� kontrol et
        if (bossHealth == null)
        {
            Debug.LogError("BossHealth referans� atanmad�!");
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
        // E�er boss sa�l��� %50'nin alt�ndaysa sprite g�r�n�r olur
        if (bossHealth.currentHealth <= bossHealth.maxHealth / 2)
        {
            spriteRenderer.enabled = true; // Sprite'� g�r�n�r yap
        }
        else
        {
            spriteRenderer.enabled = false; // Sprite'� gizle
        }
    }
}
