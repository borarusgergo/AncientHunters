using UnityEditor.Build.Content;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage megh�vva!");
        health -= damage;
        Debug.Log("J�t�kos �lete: " + health);
        if (health <= 0)
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
