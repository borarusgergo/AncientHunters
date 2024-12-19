using UnityEngine;
using UnityEngine.Events;

public enum EnemyType { Basic, Tank, Boss}

public class Enemy : MonoBehaviour
{
    public EnemyType type;
    public int health;
    public bool isDead = false;
    public int damageOnCollision = 1;

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
                health = 15;
                break;
            default:
                health = 1;
                break;
        }
    }

    public UnityEvent OnDied;

    //Ütközés a játékossal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damageOnCollision);
            }
            //Ütközés után meghal az ellenfél
            Die();
        }
    }

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

        //Collider kikapcsolása halál után
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            collider.enabled = false;
            Debug.Log("Collider kikapcsolva!");
        }

        EnemyShooting shooting = GetComponentInChildren<EnemyShooting>();
        if (shooting == null)
        {
            Debug.LogError("EnemyShooting komponens nincs");
        }
        else
        {
            shooting.canShoot = false;
            Debug.Log("Nem lõhet az enemy!");
        }

        if (OnDied != null)
        {
            OnDied.Invoke();
            Debug.Log("Animáció mehívva!");
        }
        Debug.Log("Ellenség meghalt!");
        GameManager.Instance.EnemyDied();
        Destroy(gameObject,1f); //A delay az animáció miatt van ott
    }
}