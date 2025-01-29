using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        // Oyun sahnesini y�kler
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        // Ayarlar men�s�n� a�ar (ba�ka bir sahne veya panel olabilir)
        Debug.Log("Ayarlar Men�s� A��ld�!");
    }

    public void QuitGame()
    {
        // Oyundan ��kar
        Debug.Log("Oyun Kapat�ld�!");
        Application.Quit();
    }
}
