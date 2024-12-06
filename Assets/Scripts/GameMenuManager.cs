using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuManager : MonoBehaviour
{
    [Header("Canvas References")]
    public GameObject mainMenuCanvas;
    public GameObject levelSelectCanvas;
    public GameObject gameOverCanvas;

    // Singleton for easy access
    public static GameMenuManager Instance { get; private set; }

    public static bool gameStarted = false;

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Make sure it doesn't get destroyed between scene loads
        }
    }

    void Start()
    {
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuCanvas.SetActive(true);
        levelSelectCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }

    public void ShowLevelSelect()
    {
        mainMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
    }

    public void ShowGameOverScreen()
    {
        mainMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }

    public void StartGame()
    {
        // Hide all menus and load the main game scene
        HideAllCanvases();
        gameStarted = true;
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RetryLevel()
    {
        // Reload the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        // Quit the application
        Application.Quit();
    }

    private void HideAllCanvases()
    {
        mainMenuCanvas.SetActive(false);
        levelSelectCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
    }
}

