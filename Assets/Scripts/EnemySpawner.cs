using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    public GameObject TankEnemyPrefab;
    public GameObject BossEnemyPrefab;

    public Transform spawnPoint;

    void Start()
    {
        LoadEnemiesFromJson();
    }

    void LoadEnemiesFromJson()
    {
        // Betöltjük a JSON fájlt a Resources mappából
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        string SceneAsString = currentSceneIndex.ToString();

        TextAsset jsonFile = Resources.Load<TextAsset>("level"+currentSceneIndex);

        if (jsonFile != null)
        {
            // A JSON fájl deszerializálása a megfelelõ osztályokba
            LevelWrapper levelWrapper = JsonUtility.FromJson<LevelWrapper>(jsonFile.text);

            if (levelWrapper != null && levelWrapper.levelData != null)
            {
                Debug.Log("Pálya adatok betöltve: ");
                Debug.Log("Szélesség: " + levelWrapper.levelData.width + ", Magasság: " + levelWrapper.levelData.height);
                Debug.Log("Játékos kezdõpozíció: (" + levelWrapper.levelData.playerStartPos.x + ", " + levelWrapper.levelData.playerStartPos.y + ")");

                //A képernyõ szélességének lekérése
                Camera mainCamera = Camera.main;
                Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

                // Ellenségek spawnolása
                foreach (var enemyData in levelWrapper.levelData.enemies)
                {
                    Debug.Log("Ellenség típusa: " + enemyData.type + ", Pozíció: (" + enemyData.position.x + ", " + enemyData.position.y + ")");
                    GameObject prefabToSpawn = null;

                    // A típus alapján választjuk ki a megfelelõ prefab-ot
                    switch (enemyData.type)
                    {
                        case "Basic":
                            prefabToSpawn = BasicEnemyPrefab;
                            break;
                        case "Tank":
                            prefabToSpawn = TankEnemyPrefab;
                            break;
                        case "Boss":
                            prefabToSpawn = BossEnemyPrefab;
                            break;
                        default:
                            Debug.LogError("Ismeretlen ellenség típus: " + enemyData.type);
                            break;
                    }

                    // Ha megtaláltuk a prefab-ot, spawnoljuk
                    if (prefabToSpawn != null)
                    {
                        float xPos = Mathf.Lerp(-screenBounds.x + 1f, screenBounds.x - 1f, enemyData.position.x / (float)levelWrapper.levelData.width);
                        Vector3 spawnPosition = new Vector3(xPos, enemyData.position.y, 0f);
                        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

                        GameManager.Instance.AddEnemy();
                    }
                }
            }
            else
            {
                Debug.LogError("A JSON fájl nem tartalmaz érvényes pálya adatokat vagy ellenségeket!");
            }
        }
        else
        {
            Debug.LogError("Nem található JSON fájl!");
        }
    }
}
