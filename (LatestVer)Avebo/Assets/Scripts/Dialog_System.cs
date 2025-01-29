using UnityEngine;

public class SpriteHealthListener : MonoBehaviour
{
    public BossHealth bossHealth; // Takip edilecek boss'un sa�l�k scripti
    public SpriteRenderer spriteRenderer; // Bu scriptin kontrol edece�i sprite renderer
    [Range(0f, 1f)] public float visibilityThreshold = 0.5f; // G�r�n�rl�k e�i�i (0-1 aras�nda bir y�zde)
    public float fadeSpeed = 2f; // Fade h�z�n� kontrol eder (daha b�y�k de�er daha h�zl� fade olur)
    public float visibleDuration = 3f; // Sprite'�n tamamen g�r�n�r kalaca�� s�re

    private float targetAlpha = 0f; // Sprite'�n ula�maya �al��aca�� hedef alpha de�eri
    private float visibleTimer = 0f; // Sprite'�n g�r�n�r oldu�u s�reyi takip eden saya�
    private Color spriteColor;

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

        // Sprite'�n ba�lang�� rengini kaydet
        if (spriteRenderer != null)
        {
            spriteColor = spriteRenderer.color;
            spriteColor.a = 0f; // Ba�lang��ta tamamen g�r�nmez yap
            spriteRenderer.color = spriteColor;
        }
    }

    void Update()
    {
        if (bossHealth != null)
        {
            UpdateSpriteVisibility();
            HandleVisibleTimer();
            FadeSprite();
        }
    }

    void UpdateSpriteVisibility()
    {
        // Sa�l�k e�ik de�erinin alt�ndaysa g�r�n�r hale getir
        if (bossHealth.currentHealth <= bossHealth.maxHealth * visibilityThreshold)
        {
            visibleTimer = visibleDuration; // G�r�n�rl�k s�resini ba�lat
            targetAlpha = 1f; // Sprite tamamen g�r�n�r olacak
        }
    }

    void HandleVisibleTimer()
    {
        // E�er g�r�n�rl�k s�resi aktifse ve s�f�rdan b�y�kse
        if (visibleTimer > 0f)
        {
            visibleTimer -= Time.deltaTime; // S�reyi azalt

            // G�r�n�rl�k s�resi bittiyse fade out ba�lat
            if (visibleTimer <= 0f)
            {
                targetAlpha = 0f; // Sprite tamamen g�r�nmez olacak
                Debug.Log("Fade-out ba�lat�ld�.");
            }
        }
    }

    void FadeSprite()
    {
        if (spriteRenderer != null)
        {
            // Mevcut alpha de�erini hedef alpha'ya do�ru yumu�ak bir �ekilde yakla�t�r
            float currentAlpha = Mathf.MoveTowards(spriteRenderer.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            Debug.Log($"Current Alpha: {currentAlpha}, Target Alpha: {targetAlpha}");

            // Sprite'�n rengini g�ncelle
            spriteColor.a = currentAlpha;
            spriteRenderer.color = spriteColor;
        }
    }
}
