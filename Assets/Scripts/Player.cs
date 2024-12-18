using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 5;
    public float currentHealth;
    public bool isImmortal = false;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;

        healthBar.UpdateHealthBar(maxHealth, currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isImmortal)
        {
            Debug.Log("A játékos halhatatlan!");
            return;
        }
        currentHealth -= damage;
        healthBar.UpdateHealthBar(maxHealth, currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player meghalt!");
        GameManager.Instance.PlayerDied();
        Destroy(gameObject);
    }
}
