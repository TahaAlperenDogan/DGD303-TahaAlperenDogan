using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteFadeSequence : MonoBehaviour
{
    public List<Sprite> sprites; // Sýrasýyla gösterilecek sprite'lar
    public float fadeDuration = 1f; // Fade in/out süresi
    public float displayDuration = 1f; // Her sprite’ýn ekranda kalma süresi

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        // SpriteRenderer bileþeni ekle veya kontrol et
        spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0); // Baþlangýçta tamamen þeffaf
    }

    void Start()
    {
        StartCoroutine(DisplaySprites());
    }

    private IEnumerator DisplaySprites()
    {
        foreach (var sprite in sprites)
        {
            // Sprite'ý güncelle
            spriteRenderer.sprite = sprite;

            // Fade in
            yield return StartCoroutine(Fade(0, 1));

            // Ekranda bir süre bekle
            yield return new WaitForSeconds(displayDuration);

            // Fade out
            yield return StartCoroutine(Fade(1, 0));
        }

        // Spriteler bittikten sonra sahneye geçiþ yap
        SceneManager.LoadScene("GameplayScene");
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

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
