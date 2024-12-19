using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static float globalSpeedMulitplier = 1f; //Globális sebesség szorzó

    public GameOverScreen GameOverScreen;

    private int enemiesAlive = 0;
    public float delayBeforeNextLevel = 1f;

    public string lastSceneName;

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
            Debug.Log("GameManager törölte: " +  gameObject.name);
        }
    }

    void LoadNextLevel()
    {
        // A következő pálya betöltése
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        globalSpeedMulitplier = 1f; //Sebesség szorzó viszaállítása új jelenet betöltése előtt

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Nincs több pálya!"); // Hibaüzenet, ha nincs több pálya
        }
    }

    public void PlayerDied()
    {
        //Az aktuális jelent nevét elmentjük
        lastSceneName = SceneManager.GetActiveScene().name;

        //Az ellensége számának alaphelyzetbe állítása halál után
        ResetEnemyCount();

        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        Debug.Log("Ellenség meghalt, élő ellenségek száma: " +  enemiesAlive);
        globalSpeedMulitplier += 0.1f;

        if (enemiesAlive <= 0)
        {
            Debug.Log("Minden ellenség meghalt! Pálya teljesítve.");
            Player player = FindAnyObjectByType<Player>();
            if (player != null)
            {
                player.isImmortal = true;
            }
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

    private void ResetEnemyCount()
    {
        enemiesAlive = 0;
    }
}
