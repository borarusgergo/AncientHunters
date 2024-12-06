using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int enemiesAlive = 0;

    void Awake()
    {
        Debug.Log("GameManager betöltött!");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            Debug.Log("GameManager Törölte ezt: " + gameObject.name);
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
        Debug.Log("Ellenség meghalt, élõ ellenségek száma: " +  enemiesAlive);
        if (enemiesAlive <= 0)
        {
            GameMenuManager.Instance.ShowGameOverScreen();
            Debug.Log("Minden ellenség meghalt! Pálya teljesítve.");
        }
    }
    
    public void AddEnemy()
    {
        enemiesAlive++;
    }
}
