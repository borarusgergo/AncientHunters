using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameOverScreen GameOverScreen;

    private int enemiesAlive = 0;
    
    

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
            //
        }
    }

    void LoadNextLevel()
    {
        // A következõ pálya betöltése
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

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
        Debug.Log("Game Over");
        SceneManager.LoadScene("GameOver");
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        Debug.Log("Ellenség meghalt, élõ ellenségek száma: " +  enemiesAlive);
        if (enemiesAlive <= 0)
        {
            Debug.Log("Minden ellenség meghalt! Pálya teljesítve.");
            LoadNextLevel(); //Következõ pálya
            
        }
    }
    
    public void AddEnemy()
    {
        enemiesAlive++;
    }

    


}
