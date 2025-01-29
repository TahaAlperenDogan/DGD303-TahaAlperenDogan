using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoaderWithSound : MonoBehaviour
{
    public Button loadSceneButton; // Buton referans�
    public string sceneName; // Y�klenmek istenen sahnenin ismi
    public AudioClip soundClip; // �al�nacak ses dosyas�
    public AudioSource audioSource; // Ses kayna�� referans�

    void Start()
    {
        // Butona t�klama olay�n� dinle
        loadSceneButton.onClick.AddListener(PlaySoundAndLoadScene);
    }

    void PlaySoundAndLoadScene()
    {
        if (soundClip != null && audioSource != null)
        {
            // Ses �al
            audioSource.clip = soundClip;
            audioSource.Play();

            // Sesin s�resi kadar bekleyip sahneyi y�kle
            Invoke("LoadScene", soundClip.length);
        }
        else
        {
            // E�er ses yoksa do�rudan sahneye ge�
            Debug.LogWarning("Ses dosyas� veya AudioSource eksik!");
            LoadScene();
        }
    }

    void LoadScene()
    {
        // Belirtilen sahneyi y�kle
        SceneManager.LoadScene(sceneName);
    }
}
