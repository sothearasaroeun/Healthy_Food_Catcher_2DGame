using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToIntru()
    {
        SceneManager.LoadScene("IntroScene"); // use your actual scene name
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("MainScene"); // use your actual scene name
    }
    public void GoToHome()
    {
        SceneManager.LoadScene("MenuScene"); // use your actual scene name
    }
}
