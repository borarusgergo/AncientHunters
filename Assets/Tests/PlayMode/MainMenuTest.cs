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
        // Create a new GameObject and attach the MainMenu script
        mainMenuObject = new GameObject("MainMenu");
        mainMenu = mainMenuObject.AddComponent<MainMenu>();
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the created GameObject after each test
        Object.Destroy(mainMenuObject);
    }

    [UnityTest]
    public IEnumerator StartGame_CallsSceneManagerLoadScene()
    {
        // Arrange: Create a mock scene name for testing
        string testSceneName = "Level1";

        // Act: Call the StartGame method and simulate loading the scene asynchronously
        mainMenu.StartGame();

        // Wait until the scene has loaded
        yield return new WaitUntil(() => SceneManager.GetActiveScene().name == testSceneName);

        // Assert: Verify if SceneManager.LoadScene was called with the correct scene
        Assert.AreEqual(testSceneName, SceneManager.GetActiveScene().name, "The scene should switch to the correct level.");
    }

    [Test]
    public void QuitButton_CallsApplicationQuit()
    {
        // Arrange: Expect a log message (since Application.Quit doesn't execute in the editor)
        LogAssert.Expect(LogType.Log, "Kilépés...");

        // Act: Call the QuitButton method
        mainMenu.QuitButton();

        // Assert: Check if the log was triggered
        LogAssert.NoUnexpectedReceived();
    }
}
