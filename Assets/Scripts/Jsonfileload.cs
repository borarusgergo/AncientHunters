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
    public Position position; //Enemy pozíció
}

[System.Serializable]
public class LevelData
{
    public int width; //Pálya szélesség
    public int height; //Pálya magasság
    public Position playerStartPos; //Játékos kezdõ pozícó
    public List<EnemyData> enemies;
}

[System.Serializable]
public class LevelWrapper
{
    public LevelData levelData;
}

