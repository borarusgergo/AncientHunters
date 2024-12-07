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
            Debug.Log("GameManager t�r�lte: " +  gameObject.name);
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
        }
    }
    
    public void AddEnemy()
    {
        enemiesAlive++;
    }
}
