using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    [Header("Animation Settings")]
    public Sprite[] sprites; // Animasyonda oynatýlacak sprite'lar
    public float frameRate = 0.2f; // Frame deðiþim hýzý (saniye cinsinden)
    public Sprite loopSprite; // K tuþuna basýldýðýnda anýnda oynatýlacak sprite

    private int currentFrame = 0; // Þu anki frame'in index'i
    private SpriteRenderer spriteRenderer; // Sprite'larý göstermek için gerekli
    private float timer = 0f; // Frame geçiþi için zamanlayýcý
    private bool isPlaying = true; // Animasyonun oynayýp oynamadýðýný kontrol eder
    private bool playLoopSprite = false; // Döngüye eklenen sprite'ýn oynatýlýp oynatýlmadýðýný kontrol eder

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Bu script bir SpriteRenderer bileþeniyle kullanýlmalý!");
            return;
        }

        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[0]; // Ýlk frame'i göster
        }
    }

    void Update()
    {
        // Animasyonu oynat
        if (isPlaying && sprites.Length > 0 && !playLoopSprite)
        {
            timer += Time.deltaTime; // Zamaný artýr

            if (timer >= frameRate)
            {
                timer -= frameRate; // Zamanlayýcýyý sýfýrla
                currentFrame = (currentFrame + 1) % sprites.Length; // Sýradaki frame'e geç
                spriteRenderer.sprite = sprites[currentFrame];
            }
        }

        // Loop sprite oynatýlýyorsa
        if (playLoopSprite)
        {
            spriteRenderer.sprite = loopSprite;
            playLoopSprite = false; // Loop sprite bir kez oynatýldýktan sonra dur
        }

        // K tuþuna basýldýðýnda döngüye yeni bir sprite ekle ve hemen oynat
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayLoopSprite();
        }
    }

    // Loop sprite'ý hemen oynatýr
    void PlayLoopSprite()
    {
        if (loopSprite != null)
        {
            playLoopSprite = true; // Loop sprite oynatýlacak
            timer = 0f; // Zamanlayýcýyý sýfýrla
            Debug.Log("Loop sprite anýnda oynatýldý!");
        }
        else
        {
            Debug.LogWarning("Loop Sprite atanmadý, lütfen bir sprite seçin.");
        }
    }
}
