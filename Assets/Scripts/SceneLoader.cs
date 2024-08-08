using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadUniverScene()
    {
        SceneManager.LoadScene("Univer");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
