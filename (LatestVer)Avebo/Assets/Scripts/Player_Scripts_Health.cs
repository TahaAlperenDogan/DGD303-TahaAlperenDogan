using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yüklemek için gerekli

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Oyuncunun maksimum caný
    public int currentHealth; // Oyuncunun mevcut caný

    void Start()
    {
        currentHealth = maxHealth; // Oyuncu baþlangýçta maksimum cana sahip
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasarý mevcut candan çýkar
        Debug.Log("Player Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player defeated!");
        // Oyun bitti ekraný veya sahne yenileme
        SceneManager.LoadScene("GameOverScene"); // "GameOverScene" adýnda bir sahne oluþturulmalý
    }

    // Saðlýk göstergesi için
    void OnGUI()
    {
        // Birinci satýr
        GUI.Label(new Rect(10, 10, 200, 20), "Player Status:");
        // Ýkinci satýr
        GUI.Label(new Rect(10, 30, 200, 20), "Health: " + currentHealth);
    }
}
