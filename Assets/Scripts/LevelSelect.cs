using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public string levelName;
    public void loadLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void MainManuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
