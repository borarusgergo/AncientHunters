using UnityEngine;

public class EnemyShooting : MonoBehaviour 
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f; //Sebesség késõbb változó type szerint
    public float nextFireTime;
    public float enemyBulletSpeed = 5f;
    public bool canShoot = true;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null )
            {
                rb.linearVelocity = Vector2.down * enemyBulletSpeed;
            }
        }
        else
        {
            Debug.LogError("BulletPrefab vagy FirePoint nincs beállítva!");
        }
    }
}
