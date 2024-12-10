using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public void GameOver()
    {
        gameObject.SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainManuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
