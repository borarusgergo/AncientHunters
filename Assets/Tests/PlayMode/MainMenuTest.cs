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
        // El�k�sz�t�s: �j GameObject l�trehoz�sa �s a MainMenu script hozz�rendel�se
        mainMenuObject = new GameObject("MainMenu");
        mainMenu = mainMenuObject.AddComponent<MainMenu>();
    }

    [TearDown]
    public void Teardown()
    {
        // Takar�t�s: A l�trehozott GameObject elt�vol�t�sa minden teszt ut�n
        Object.Destroy(mainMenuObject);
    }

    [UnityTest]
    public IEnumerator StartGame_CallsSceneManagerLoadScene()
    {
        // El�k�sz�t�s: Tesztel�shez egy �ln�v a jelenethez
        string testSceneName = "Level1";

        // Akci�: A StartGame met�dus megh�v�sa �s a jelenet bet�lt�s�nek szimul�l�sa aszinkron m�don
        mainMenu.StartGame();

        // V�rakoz�s: A teszt, hogy a jelenet bet�lt�d�se befejez�d�tt-e
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == testSceneName);

        // Ellen�rz�s: Meger�s�tj�k, hogy a SceneManager.LoadScene a megfelel� jelenetet t�lt�tte be
        Assert.AreEqual(testSceneName, SceneManager.GetActiveScene().name, "A jelenetnek a megfelel� szintre kell v�ltania.");
    }

    [Test]
    public void QuitButton_CallsApplicationQuit()
    {
        // El�k�sz�t�s: V�runk egy log �zenetre (mivel az Application.Quit nem fut le a szerkeszt�ben)
        LogAssert.Expect(LogType.Log, "Kil�p�s...");

        // Akci�: A QuitButton met�dus megh�v�sa
        mainMenu.QuitButton();

        // Ellen�rz�s: Ellen�rizz�k, hogy a log �zenet meg lett-e h�vva
        LogAssert.NoUnexpectedReceived();
    }
}
