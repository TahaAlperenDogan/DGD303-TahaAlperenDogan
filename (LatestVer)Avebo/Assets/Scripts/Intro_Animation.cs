using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteFadeSequence : MonoBehaviour
{
    public List<Sprite> sprites; // S�ras�yla g�sterilecek sprite'lar
    public float fadeDuration = 1f; // Fade in/out s�resi
    public float displayDuration = 1f; // Her sprite��n ekranda kalma s�resi
    public AudioClip fadeInSound; // Fade-in s�ras�nda �al�nacak ses
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // SpriteRenderer bile�eni ekle veya kontrol et
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0); // Ba�lang��ta tamamen �effaf

        // AudioSource bile�eni ekle
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; // Ses ba�lang��ta �almas�n
    }

    void Start()
    {
        StartCoroutine(DisplaySprites());
    }

    private IEnumerator DisplaySprites()
    {
        foreach (var sprite in sprites)
        {
            // Sprite'� g�ncelle
            spriteRenderer.sprite = sprite;

            // Fade in (ses ile birlikte)
            yield return StartCoroutine(Fade(0, 1, true));

            // Ekranda bir s�re bekle
            yield return new WaitForSeconds(displayDuration);

            // Fade out
            yield return StartCoroutine(Fade(1, 0, false));
        }

        // Spriteler bittikten sonra sahneye ge�i� yap
        SceneManager.LoadScene("TextIntro");
    }

    private IEnumerator Fade(float startAlpha, float endAlpha, bool playSound)
    {
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        if (playSound && fadeInSound != null && audioSource != null)
        {
            audioSource.clip = fadeInSound;
            audioSource.Play();
        }

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / fadeDuration);
            spriteRenderer.color = color;
            yield return null;
        }

        color.a = endAlpha;
        spriteRenderer.color = color;
    }
}
