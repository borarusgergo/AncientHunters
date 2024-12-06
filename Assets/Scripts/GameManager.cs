using UnityEngine;

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
        }
    }

    public void PlayerDied()
    {
        Debug.Log("Game Over");
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
