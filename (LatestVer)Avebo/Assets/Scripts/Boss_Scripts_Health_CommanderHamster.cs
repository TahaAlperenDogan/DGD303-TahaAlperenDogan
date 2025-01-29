using UnityEngine;
using UnityEngine.SceneManagement; // Sahne yönetimi için gerekli

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100; // Boss'un maksimum caný
    public int currentHealth; // Boss'un mevcut caný

    void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta maksimum cana sahip
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasarý mevcut candan çýkar
        Debug.Log("Boss Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss defeated!");
        Destroy(gameObject); // Boss'u yok et
        SceneManager.LoadScene("GameEnd"); // VictoryTemp sahnesine geçiþ yap
    }

    // Opsiyonel: Saðlýk göstergesi için
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Boss Health: " + currentHealth);
    }
}
