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
        }
    }
    
    public void AddEnemy()
    {
        enemiesAlive++;
    }
}
