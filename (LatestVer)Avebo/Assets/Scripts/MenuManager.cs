using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini yükler
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        // Ayarlar menüsünü açar (baþka bir sahne veya panel olabilir)
        Debug.Log("Ayarlar Menüsü Açýldý!");
    }

    public void QuitGame()
    {
        // Oyundan çýkar
        Debug.Log("Oyun Kapatýldý!");
        Application.Quit();
    }
}
