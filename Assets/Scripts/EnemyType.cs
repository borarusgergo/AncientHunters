using UnityEngine;
using UnityEngine.Events;

public enum EnemyType { Basic, Tank, Boss}

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public int health;
    private bool isDead = false;

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

    public UnityEvent OnDied;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        Debug.Log("Ellenség élete: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        if (OnDied != null)
        {
            OnDied.Invoke();
            Debug.Log("Animáció mehívva!");
        }
        Debug.Log("Ellenség meghalt!");
        GameManager.Instance.EnemyDied();
        Destroy(gameObject,1f); //Animáció miatt delay kell bele, ezért van az isDead bool ezt biztos jobban is meg lehet oldani de így is mûködik
    }
}