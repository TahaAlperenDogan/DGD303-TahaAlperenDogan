using UnityEngine;

public class SpriteHealthListener : MonoBehaviour
{
    public BossHealth bossHealth; // Takip edilecek boss'un saðlýk scripti
    public SpriteRenderer spriteRenderer; // Bu scriptin kontrol edeceði sprite renderer
    [Range(0f, 1f)] public float visibilityThreshold = 0.5f; // Görünürlük eþiði (0-1 arasýnda bir yüzde)
    public float fadeSpeed = 2f; // Fade hýzýný kontrol eder (daha büyük deðer daha hýzlý fade olur)
    public float visibleDuration = 3f; // Sprite'ýn tamamen görünür kalacaðý süre

    private float targetAlpha = 0f; // Sprite'ýn ulaþmaya çalýþacaðý hedef alpha deðeri
    private float visibleTimer = 0f; // Sprite'ýn görünür olduðu süreyi takip eden sayaç
    private Color spriteColor;

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

        // Sprite'ýn baþlangýç rengini kaydet
        if (spriteRenderer != null)
        {
            spriteColor = spriteRenderer.color;
            spriteColor.a = 0f; // Baþlangýçta tamamen görünmez yap
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
        // Saðlýk eþik deðerinin altýndaysa görünür hale getir
        if (bossHealth.currentHealth <= bossHealth.maxHealth * visibilityThreshold)
        {
            visibleTimer = visibleDuration; // Görünürlük süresini baþlat
            targetAlpha = 1f; // Sprite tamamen görünür olacak
        }
    }

    void HandleVisibleTimer()
    {
        // Eðer görünürlük süresi aktifse ve sýfýrdan büyükse
        if (visibleTimer > 0f)
        {
            visibleTimer -= Time.deltaTime; // Süreyi azalt

            // Görünürlük süresi bittiyse fade out baþlat
            if (visibleTimer <= 0f)
            {
                targetAlpha = 0f; // Sprite tamamen görünmez olacak
                Debug.Log("Fade-out baþlatýldý.");
            }
        }
    }

    void FadeSprite()
    {
        if (spriteRenderer != null)
        {
            // Mevcut alpha deðerini hedef alpha'ya doðru yumuþak bir þekilde yaklaþtýr
            float currentAlpha = Mathf.MoveTowards(spriteRenderer.color.a, targetAlpha, fadeSpeed * Time.deltaTime);
            Debug.Log($"Current Alpha: {currentAlpha}, Target Alpha: {targetAlpha}");

            // Sprite'ýn rengini güncelle
            spriteColor.a = currentAlpha;
            spriteRenderer.color = spriteColor;
        }
    }
}
