using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject BasicEnemyPrefab;
    public GameObject TankEnemyPrefab;
    public GameObject BossEnemyPrefab;

    public Transform spawnPoint;

    void Start()
    {
        if(GameMenuManager.gameStarted)
        {
            LoadEnemiesFromJson();
        }
    }

    void LoadEnemiesFromJson()
    {
        // Betöltjük a JSON fájlt a Resources mappából
        TextAsset jsonFile = Resources.Load<TextAsset>("level1");

        if (jsonFile != null)
        {
            // A JSON fájl deszerializálása a megfelelõ osztályokba
            LevelWrapper levelWrapper = JsonUtility.FromJson<LevelWrapper>(jsonFile.text);

            if (levelWrapper != null && levelWrapper.levelData != null)
            {
                Debug.Log("Pálya adatok betöltve: ");
                Debug.Log("Szélesség: " + levelWrapper.levelData.width + ", Magasság: " + levelWrapper.levelData.height);
                Debug.Log("Játékos kezdõpozíció: (" + levelWrapper.levelData.playerStartPos.x + ", " + levelWrapper.levelData.playerStartPos.y + ")");

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
                        Vector3 spawnPosition = new Vector3(enemyData.position.x, enemyData.position.y, 0f);
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
