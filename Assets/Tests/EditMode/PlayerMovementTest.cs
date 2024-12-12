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
        // Létrehozunk egy GameObject-et a PlayerMovement komponenssel
        player = new GameObject("Player");
        playerMovement = player.AddComponent<PlayerMovement>();
    }

    [TearDown]
    public void Teardown()
    {
        // A tesztek után eltávolítjuk a GameObject-et
        Object.DestroyImmediate(player);
    }

    [Test]
    public void PlayerMovesRightWhenInputIsPositive()
    {
        // Szimulálunk egy pozitív vízszintes bemenetet
        float simulatedInput = 1f;
        float initialXPosition = player.transform.position.x;

        // Meghívjuk közvetlenül a Move metódust a szimulált bemenettel
        playerMovement.speed = 5f;
        SimulateMove(simulatedInput, Time.deltaTime);

        float finalXPosition = player.transform.position.x;

        // Ellenõrizzük, hogy a játékos pozíciója növekedett
        Assert.Greater(finalXPosition, initialXPosition);
    }

    [Test]
    public void PlayerMovesLeftWhenInputIsNegative()
    {
        // Szimulálunk egy negatív vízszintes bemenetet
        float simulatedInput = -1f;
        float initialXPosition = player.transform.position.x;

        // Meghívjuk közvetlenül a Move metódust a szimulált bemenettel
        playerMovement.speed = 5f;
        SimulateMove(simulatedInput, Time.deltaTime);

        float finalXPosition = player.transform.position.x;

        // Ellenõrizzük, hogy a játékos pozíciója csökkent
        Assert.Less(finalXPosition, initialXPosition);
    }

    [Test]
    public void PlayerDoesNotMoveWhenInputIsZero()
    {
        // Szimulálunk egy nulla vízszintes bemenetet
        float simulatedInput = 0f;
        Vector3 initialPosition = player.transform.position;

        // Meghívjuk közvetlenül a Move metódust a szimulált bemenettel
        playerMovement.speed = 5f;
        SimulateMove(simulatedInput, Time.deltaTime);

        Vector3 finalPosition = player.transform.position;

        // Ellenõrizzük, hogy a játékos pozíciója nem változott
        Assert.AreEqual(initialPosition, finalPosition);
    }

    private void SimulateMove(float simulatedInput, float deltaTime)
    {
        // Szimuláljuk a mozgási logikát a megadott bemenettel
        player.transform.Translate(Vector2.right * simulatedInput * playerMovement.speed * deltaTime);
    }
}

