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

    //�tk�z�s a j�t�kossal
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damageOnCollision);
            }
            //�tk�z�s ut�n meghal az ellenf�l
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        Debug.Log("Ellens�g �lete: " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        //Collider kikapcsol�sa hal�l ut�n
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
            Debug.Log("Nem l�het az enemy!");
        }

        if (OnDied != null)
        {
            OnDied.Invoke();
            Debug.Log("Anim�ci� meh�vva!");
        }
        Debug.Log("Ellens�g meghalt!");
        GameManager.Instance.EnemyDied();
        Destroy(gameObject,1f); //A delay az anim�ci� miatt van ott
    }
}