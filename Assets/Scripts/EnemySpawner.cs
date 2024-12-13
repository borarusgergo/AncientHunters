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
        // Bet�ltj�k a JSON f�jlt a Resources mapp�b�l
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
        string SceneAsString = currentSceneIndex.ToString();

        TextAsset jsonFile = Resources.Load<TextAsset>("level"+currentSceneIndex);

        if (jsonFile != null)
        {
            // A JSON f�jl deszerializ�l�sa a megfelel� oszt�lyokba
            LevelWrapper levelWrapper = JsonUtility.FromJson<LevelWrapper>(jsonFile.text);

            if (levelWrapper != null && levelWrapper.levelData != null)
            {
                Debug.Log("P�lya adatok bet�ltve: ");
                Debug.Log("Sz�less�g: " + levelWrapper.levelData.width + ", Magass�g: " + levelWrapper.levelData.height);
                Debug.Log("J�t�kos kezd�poz�ci�: (" + levelWrapper.levelData.playerStartPos.x + ", " + levelWrapper.levelData.playerStartPos.y + ")");

                //A k�perny� sz�less�g�nek lek�r�se
                Camera mainCamera = Camera.main;
                Vector2 screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));

                // Ellens�gek spawnol�sa
                foreach (var enemyData in levelWrapper.levelData.enemies)
                {
                    Debug.Log("Ellens�g t�pusa: " + enemyData.type + ", Poz�ci�: (" + enemyData.position.x + ", " + enemyData.position.y + ")");
                    GameObject prefabToSpawn = null;

                    // A t�pus alapj�n v�lasztjuk ki a megfelel� prefab-ot
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
                            Debug.LogError("Ismeretlen ellens�g t�pus: " + enemyData.type);
                            break;
                    }

                    // Ha megtal�ltuk a prefab-ot, spawnoljuk
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
                Debug.LogError("A JSON f�jl nem tartalmaz �rv�nyes p�lya adatokat vagy ellens�geket!");
            }
        }
        else
        {
            Debug.LogError("Nem tal�lhat� JSON f�jl!");
        }
    }
}
