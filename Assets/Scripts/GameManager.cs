using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int enemiesAlive = 0;

    void Awake()
    {
        Debug.Log("GameManager bet�lt�tt!");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            Debug.Log("GameManager T�r�lte ezt: " + gameObject.name);
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Game Over");
        GameMenuManager.Instance.ShowGameOverScreen();
    }

    public void EnemyDied()
    {
        enemiesAlive--;
        Debug.Log("Ellens�g meghalt, �l� ellens�gek sz�ma: " +  enemiesAlive);
        if (enemiesAlive <= 0)
        {
            GameMenuManager.Instance.ShowGameOverScreen();
            Debug.Log("Minden ellens�g meghalt! P�lya teljes�tve.");
        }
    }
    
    public void AddEnemy()
    {
        enemiesAlive++;
    }
}
