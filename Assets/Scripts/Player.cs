using UnityEditor.Build.Content;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 5;

    public void TakeDamage(int damage)
    {
        Debug.Log("TakeDamage meghívva!");
        health -= damage;
        Debug.Log("Játékos élete: " + health);
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
