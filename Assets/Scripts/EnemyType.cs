using UnityEngine;

public enum EnemyType { Basic, Tank, Boss}

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public int health;

    void Start()
    {
       switch (type)
        {
            case EnemyType.Basic:
                health = 1;
                break;
            case EnemyType.Tank:
                health = 3;
                break;
            case EnemyType.Boss:
                health = 10;
                break;
            default:
                health = 1;
                break;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Ellenség élete: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Animáció ide majd
        Debug.Log("Ellenség meghalt!");
        GameManager.Instance.EnemyDied();
        Destroy(gameObject);
    }
}