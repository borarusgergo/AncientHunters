using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public GameOverScreen GameOverScreen;

    private int enemiesAlive = 0;
    public float delayBeforeNextLevel = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("GameManager t�r�lte: " +  gameObject.name);
        }
    }

    void LoadNextLevel()
    {
        // A k�vetkez� p�lya bet�lt�se
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Nincs t�bb p�lya!"); // Hiba�zenet, ha nincs t�bb p�lya
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        Debug.Log("Ellens�g meghalt, �l� ellens�gek sz�ma: " +  enemiesAlive);

        if (enemiesAlive <= 0)
        {
            Debug.Log("Minden ellens�g meghalt! P�lya teljes�tve.");
            StartCoroutine(LoadNextLevelWithDelay());
        }
    }

    private IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(delayBeforeNextLevel);
        LoadNextLevel();
    }
    
    public void AddEnemy()
    {
        enemiesAlive++;
    }
}
