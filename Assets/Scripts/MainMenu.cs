using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Kil�p�s...");
    }

    public void StartGame()
    {
        Debug.Log("Game scene megh�vva");
        SceneManager.LoadScene("Level1");
    }
}
