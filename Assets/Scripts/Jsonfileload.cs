using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Position
{
    public float x;
    public float y;
}

[System.Serializable]
public class EnemyData
{
    public string type; //Enemy fajta
    public Position position; //Enemy poz�ci�
}

[System.Serializable]
public class LevelData
{
    public int width; //P�lya sz�less�g
    public int height; //P�lya magass�g
    public Position playerStartPos; //J�t�kos kezd� poz�c�
    public List<EnemyData> enemies;
}

[System.Serializable]
public class LevelWrapper
{
    public LevelData levelData;
}

