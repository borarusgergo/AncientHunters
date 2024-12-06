using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public int damage = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("EnemyBullet"))
            {
                Debug.Log("Ellenség lövedék eltalálta a játékost!");
                Player player = collision.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            if (gameObject.CompareTag("PlayerBullet"))
            {
                Debug.Log("A játékos eltalált egy ellenséges hajót!");
                Enemy enemy = collision.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
                Destroy(gameObject);
            }
        }
    }
}
