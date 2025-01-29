using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CrawlText : MonoBehaviour
{
    public Text crawlText;      // Normal UI Text
    public Image fadeScreen;    // UI Image (Beyaz fade i�in)
    public float scrollSpeed = 20f; // Yaz� kayd�rma h�z�
    public float duration = 10f; // Yaz�n�n ka� saniyede kaybolaca��
    public float fadeDuration = 2f; // Fade s�resi
    public string nextSceneName = "MainScene"; // A��lacak sahne

    private RectTransform textTransform;

    void Start()
    {
        textTransform = crawlText.GetComponent<RectTransform>();
        fadeScreen.color = new Color(1, 1, 1, 0); // Ba�lang��ta tam �effaf
        StartCoroutine(ScrollText());
    }

    IEnumerator ScrollText()
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            textTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fade in efekti ba�lat
        yield return StartCoroutine(FadeToWhite());

        // Belirtilen sahneye ge�i� yap
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeToWhite()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            fadeScreen.color = new Color(1, 1, 1, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeScreen.color = new Color(1, 1, 1, 1); // Tam beyaz yap
    }
}
