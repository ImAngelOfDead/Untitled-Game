using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadUniverScene()
    {
        SceneManager.LoadScene("Univer");
    }
    public void LoadMainMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSetingsMenu() 
    {
        SceneManager.LoadScene("Settings");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
