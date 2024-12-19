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
        if (!string.IsNullOrEmpty(GameManager.Instance.lastSceneName))
        {
            GameManager.globalSpeedMulitplier = 1f;
            SceneManager.LoadScene(GameManager.Instance.lastSceneName);
        }
        else
        {
            Debug.LogError("Nem található az elõzõ jelenet neve!");
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainManuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
