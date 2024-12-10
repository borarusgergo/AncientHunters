using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Kilépés...");
    }

    public void StartGame()
    {
        Debug.Log("Game scene meghívva");
        SceneManager.LoadScene("Level1");
    }
}
