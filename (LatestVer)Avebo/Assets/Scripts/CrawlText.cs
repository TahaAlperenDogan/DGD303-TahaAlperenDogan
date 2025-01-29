using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class CrawlText : MonoBehaviour
{
    public Text crawlText;      // Normal UI Text
    public Image fadeScreen;    // UI Image (Beyaz fade için)
    public float scrollSpeed = 20f; // Yazý kaydýrma hýzý
    public float duration = 10f; // Yazýnýn kaç saniyede kaybolacaðý
    public float fadeDuration = 2f; // Fade süresi
    public string nextSceneName = "MainScene"; // Açýlacak sahne

    private RectTransform textTransform;

    void Start()
    {
        textTransform = crawlText.GetComponent<RectTransform>();
        fadeScreen.color = new Color(1, 1, 1, 0); // Baþlangýçta tam þeffaf
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

        // Fade in efekti baþlat
        yield return StartCoroutine(FadeToWhite());

        // Belirtilen sahneye geçiþ yap
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
