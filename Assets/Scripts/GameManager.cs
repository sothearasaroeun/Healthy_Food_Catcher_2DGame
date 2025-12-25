using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public HeartUI heartUI;
    public ScoreUI scoreUI;

    [Header("Scenes")]
    public string scoreSceneName = "ScoreScene"; // must match scene name

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("GameManager initialized");
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // 🍔 Junk food
    public void OnJunkFoodCaught()
    {
        heartUI.LoseHeart();

        if (heartUI.currentHearts <= 0)
        {
            ShowScoreScreen();
        }
    }

    // 🥦 Healthy food
    public void OnHealthyFoodCaught()
    {
        scoreUI.AddScore(1);
    }

    void ShowScoreScreen()
    {
        SceneManager.LoadScene(scoreSceneName);
    }
}
