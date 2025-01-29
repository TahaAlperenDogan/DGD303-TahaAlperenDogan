using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Bu fonksiyon, butona atanacak
    public void QuitGame()
    {
#if UNITY_EDITOR
            // Unity Editor'de �al���yorsa, edit�rden ��kmak i�in
            UnityEditor.EditorApplication.isPlaying = false;
#else
        // Build edilen oyundan ��kmak i�in
        Application.Quit();
#endif
    }
}
