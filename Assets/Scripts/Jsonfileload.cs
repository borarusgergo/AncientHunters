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
    public string type;
    public Position position;
}

[System.Serializable]
public class LevelData
{
    public int width;
    public int height;
    public Position playerStartPos;
    public List<EnemyData> enemies;
}

[System.Serializable]
public class LevelWrapper
{
    public LevelData levelData;
}

