using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Bu fonksiyon, butona atanacak
    public void QuitGame()
    {
#if UNITY_EDITOR
            // Unity Editor'de çalýþýyorsa, editörden çýkmak için
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // Build edilen oyundan çýkmak için
        Application.Quit();
#endif
    }
}
