using UnityEngine;
using UnityEngine.SceneManagement; // Sahne y�netimi i�in gerekli

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100; // Boss'un maksimum can�
    public int currentHealth; // Boss'un mevcut can�

    void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta maksimum cana sahip
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Hasar� mevcut candan ��kar
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
        SceneManager.LoadScene("GameEnd"); // VictoryTemp sahnesine ge�i� yap
    }

    // Opsiyonel: Sa�l�k g�stergesi i�in
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), "Boss Health: " + currentHealth);
    }
}
