using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoaderWithSound : MonoBehaviour
{
    public Button loadSceneButton; // Buton referansý
    public string sceneName; // Yüklenmek istenen sahnenin ismi
    public AudioClip soundClip; // Çalýnacak ses dosyasý
    public AudioSource audioSource; // Ses kaynaðý referansý

    void Start()
    {
        // Butona týklama olayýný dinle
        loadSceneButton.onClick.AddListener(PlaySoundAndLoadScene);
    }

    void PlaySoundAndLoadScene()
    {
        if (soundClip != null && audioSource != null)
        {
            // Ses çal
            audioSource.clip = soundClip;
            audioSource.Play();

            // Sesin süresi kadar bekleyip sahneyi yükle
            Invoke("LoadScene", soundClip.length);
        }
        else
        {
            // Eðer ses yoksa doðrudan sahneye geç
            Debug.LogWarning("Ses dosyasý veya AudioSource eksik!");
            LoadScene();
        }
    }

    void LoadScene()
    {
        // Belirtilen sahneyi yükle
        SceneManager.LoadScene(sceneName);
    }
}
