using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class MainMenuTest
{
    private GameObject mainMenuObject;
    private MainMenu mainMenu;

    [SetUp]
    public void Setup()
    {
        // Elõkészítés: Új GameObject létrehozása és a MainMenu script hozzárendelése
        mainMenuObject = new GameObject("MainMenu");
        mainMenu = mainMenuObject.AddComponent<MainMenu>();
    }

    [TearDown]
    public void Teardown()
    {
        // Takarítás: A létrehozott GameObject eltávolítása minden teszt után
        Object.Destroy(mainMenuObject);
    }

    [UnityTest]
    public IEnumerator StartGame_CallsSceneManagerLoadScene()
    {
        // Elõkészítés: Teszteléshez egy álnév a jelenethez
        string testSceneName = "Level1";

        // Akció: A StartGame metódus meghívása és a jelenet betöltésének szimulálása aszinkron módon
        mainMenu.StartGame();

        // Várakozás: A teszt, hogy a jelenet betöltõdése befejezõdött-e
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == testSceneName);

        // Ellenõrzés: Megerõsítjük, hogy a SceneManager.LoadScene a megfelelõ jelenetet töltötte be
        Assert.AreEqual(testSceneName, SceneManager.GetActiveScene().name, "A jelenetnek a megfelelõ szintre kell váltania.");
    }

    [Test]
    public void QuitButton_CallsApplicationQuit()
    {
        // Elõkészítés: Várunk egy log üzenetre (mivel az Application.Quit nem fut le a szerkesztõben)
        LogAssert.Expect(LogType.Log, "Kilépés...");

        // Akció: A QuitButton metódus meghívása
        mainMenu.QuitButton();

        // Ellenõrzés: Ellenõrizzük, hogy a log üzenet meg lett-e hívva
        LogAssert.NoUnexpectedReceived();
    }
}
