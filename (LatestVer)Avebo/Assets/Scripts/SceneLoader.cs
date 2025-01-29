using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadIntroScene()
    {
        SceneManager.LoadScene("Intro");
    }
}