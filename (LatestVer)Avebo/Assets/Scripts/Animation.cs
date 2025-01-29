using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    [Header("Animation Settings")]
    public Sprite[] sprites; // Animasyonda oynat�lacak sprite'lar
    public float frameRate = 0.2f; // Frame de�i�im h�z� (saniye cinsinden)
    public Sprite loopSprite; // K tu�una bas�ld���nda an�nda oynat�lacak sprite

    private int currentFrame = 0; // �u anki frame'in index'i
    private SpriteRenderer spriteRenderer; // Sprite'lar� g�stermek i�in gerekli
    private float timer = 0f; // Frame ge�i�i i�in zamanlay�c�
    private bool isPlaying = true; // Animasyonun oynay�p oynamad���n� kontrol eder
    private bool playLoopSprite = false; // D�ng�ye eklenen sprite'�n oynat�l�p oynat�lmad���n� kontrol eder

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Bu script bir SpriteRenderer bile�eniyle kullan�lmal�!");
            return;
        }

        if (sprites.Length > 0)
        {
            spriteRenderer.sprite = sprites[0]; // �lk frame'i g�ster
        }
    }

    void Update()
    {
        // Animasyonu oynat
        if (isPlaying && sprites.Length > 0 && !playLoopSprite)
        {
            timer += Time.deltaTime; // Zaman� art�r

            if (timer >= frameRate)
            {
                timer -= frameRate; // Zamanlay�c�y� s�f�rla
                currentFrame = (currentFrame + 1) % sprites.Length; // S�radaki frame'e ge�
                spriteRenderer.sprite = sprites[currentFrame];
            }
        }

        // Loop sprite oynat�l�yorsa
        if (playLoopSprite)
        {
            spriteRenderer.sprite = loopSprite;
            playLoopSprite = false; // Loop sprite bir kez oynat�ld�ktan sonra dur
        }

        // K tu�una bas�ld���nda d�ng�ye yeni bir sprite ekle ve hemen oynat
        if (Input.GetKeyDown(KeyCode.K))
        {
            PlayLoopSprite();
        }
    }

    // Loop sprite'� hemen oynat�r
    void PlayLoopSprite()
    {
        if (loopSprite != null)
        {
            playLoopSprite = true; // Loop sprite oynat�lacak
            timer = 0f; // Zamanlay�c�y� s�f�rla
            Debug.Log("Loop sprite an�nda oynat�ld�!");
        }
        else
        {
            Debug.LogWarning("Loop Sprite atanmad�, l�tfen bir sprite se�in.");
        }
    }
}
