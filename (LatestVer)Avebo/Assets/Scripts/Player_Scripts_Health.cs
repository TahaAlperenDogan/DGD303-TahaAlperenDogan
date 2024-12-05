using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�klemek i�in gerekli

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Oyuncunun maksimum can�
    public int currentHealth; // Oyuncunun mevcut can�

    void Start()
    {
        currentHealth = maxHealth; // Oyuncu ba�lang��ta maksimum cana sahip
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasar� mevcut candan ��kar
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player defeated!");
        // Oyun bitti ekran� veya sahne yenileme
        SceneManager.LoadScene("GameOverScene"); // "GameOverScene" ad�nda bir sahne olu�turulmal�
    }

    // Sa�l�k g�stergesi i�in
    void OnGUI()
    {
        // Birinci sat�r
        GUI.Label(new Rect(10, 10, 200, 20), "Player Status:");
        // �kinci sat�r
        GUI.Label(new Rect(10, 30, 200, 20), "Health: " + currentHealth);
    }
}
