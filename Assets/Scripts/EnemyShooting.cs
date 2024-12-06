using UnityEngine;

public class EnemyShooting : MonoBehaviour 
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    public float nextFireTime;

    void Update()
    {
       if(GameMenuManager.gameStarted && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null )
            {
                rb.linearVelocity = Vector2.down * 5f;
            }
        }
        else
        {
            Debug.LogError("BulletPrefab vagy FirePoint nincs beállítva!");
        }
    }
}
