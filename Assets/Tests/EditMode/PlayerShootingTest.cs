using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;


[TestFixture]
public class PlayerShootingTest
{
    private GameObject playerGameObject;
    private PlayerShooting playerShooting;

    [SetUp]
    public void Setup()
    {
        // Létrehozunk egy tesztelésre szánt GameObject-et
        playerGameObject = new GameObject("Player");
        playerShooting = playerGameObject.AddComponent<PlayerShooting>();

        // Beállítjuk a bulletPrefab-et
        playerShooting.bulletPrefab = new GameObject("Bullet");
        playerShooting.bulletPrefab.AddComponent<Rigidbody2D>();

        // Beállítjuk a firePoint-ot
        GameObject firePoint = new GameObject("FirePoint");
        firePoint.transform.position = Vector2.zero;
        playerShooting.firePoint = firePoint.transform;

        playerShooting.bulletSpeed = 10f; // Lövedék sebességének inicializálása
    }

    [TearDown]
    public void Teardown()
    {
        // Takarítjuk az objektumokat a tesztek után
        Object.DestroyImmediate(playerGameObject);
        Object.DestroyImmediate(playerShooting.bulletPrefab);
    }

    [Test]
    public void Shoot_CreatesBulletAtFirePoint()
    {
        // Aktuális teszt: Ellenőrizzük, hogy a Shoot metódus létrehoz-e egy lövedéket a firePoint pozíciójában

        // Metódus hívása
        playerShooting.Shoot();

        // Ellenőrzés
        GameObject bullet = GameObject.Find("Bullet(Clone)");
        Assert.IsNotNull(bullet, "A lövedék nem lett példányosítva.");
        Assert.AreEqual(playerShooting.firePoint.position, bullet.transform.position, "A lövedék nem a firePoint pozíciójában lett példányosítva.");
    }

    [Test]
    public void Shoot_BulletHasCorrectVelocity()
    {
        // Aktuális teszt: Ellenőrizzük, hogy a lövedék a megfelelő sebességgel indul-e el

        // Metódus hívása
        playerShooting.Shoot();

        // Ellenőrzés
        GameObject bullet = GameObject.Find("Bullet(Clone)");
        Assert.IsNotNull(bullet, "A lövedék nem lett példányosítva.");

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb, "A lövedéknek nincs Rigidbody2D komponense.");

        Vector2 expectedVelocity = Vector2.up * playerShooting.bulletSpeed;
        Assert.AreEqual(expectedVelocity, rb.linearVelocity, "A lövedék sebessége nem megfelelő.");
    }
}

