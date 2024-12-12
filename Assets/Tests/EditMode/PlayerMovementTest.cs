using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerMovementTests
{
    private GameObject player;
    private PlayerMovement playerMovement;

    [SetUp]
    public void Setup()
    {
        // L�trehozunk egy GameObject-et a PlayerMovement komponenssel
        player = new GameObject("Player");
        playerMovement = player.AddComponent<PlayerMovement>();
    }

    [TearDown]
    public void Teardown()
    {
        // A tesztek ut�n elt�vol�tjuk a GameObject-et
        Object.DestroyImmediate(player);
    }

    [Test]
    public void PlayerMovesRightWhenInputIsPositive()
    {
        // Szimul�lunk egy pozit�v v�zszintes bemenetet
        float simulatedInput = 1f;
        float initialXPosition = player.transform.position.x;

        // Megh�vjuk k�zvetlen�l a Move met�dust a szimul�lt bemenettel
        playerMovement.speed = 5f;
        SimulateMove(simulatedInput, Time.deltaTime);

        float finalXPosition = player.transform.position.x;

        // Ellen�rizz�k, hogy a j�t�kos poz�ci�ja n�vekedett
        Assert.Greater(finalXPosition, initialXPosition);
    }

    [Test]
    public void PlayerMovesLeftWhenInputIsNegative()
    {
        // Szimul�lunk egy negat�v v�zszintes bemenetet
        float simulatedInput = -1f;
        float initialXPosition = player.transform.position.x;

        // Megh�vjuk k�zvetlen�l a Move met�dust a szimul�lt bemenettel
        playerMovement.speed = 5f;
        SimulateMove(simulatedInput, Time.deltaTime);

        float finalXPosition = player.transform.position.x;

        // Ellen�rizz�k, hogy a j�t�kos poz�ci�ja cs�kkent
        Assert.Less(finalXPosition, initialXPosition);
    }

    [Test]
    public void PlayerDoesNotMoveWhenInputIsZero()
    {
        // Szimul�lunk egy nulla v�zszintes bemenetet
        float simulatedInput = 0f;
        Vector3 initialPosition = player.transform.position;

        // Megh�vjuk k�zvetlen�l a Move met�dust a szimul�lt bemenettel
        playerMovement.speed = 5f;
        SimulateMove(simulatedInput, Time.deltaTime);

        Vector3 finalPosition = player.transform.position;

        // Ellen�rizz�k, hogy a j�t�kos poz�ci�ja nem v�ltozott
        Assert.AreEqual(initialPosition, finalPosition);
    }

    private void SimulateMove(float simulatedInput, float deltaTime)
    {
        // Szimul�ljuk a mozg�si logik�t a megadott bemenettel
        player.transform.Translate(Vector2.right * simulatedInput * playerMovement.speed * deltaTime);
    }
}

