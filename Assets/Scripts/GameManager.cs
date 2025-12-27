using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Stats")]
    public int score;
    public int hearts;

    [Header("UI Elements")]
    public Text scoreText;
    public Image[] heartImages;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene")
        {
            // Find ScoreText dynamically
            GameObject scoreObj = GameObject.Find("ScoreText");
            scoreText = scoreObj != null ? scoreObj.GetComponent<Text>() : null;

            // Find Hearts dynamically
            GameObject heartsParent = GameObject.Find("Hearts");
            heartImages = heartsParent != null ? heartsParent.GetComponentsInChildren<Image>() : null;

            ResetStats();
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void LoseHeart()
    {
        hearts--;

        if (hearts <= 0)
        {
            hearts = 0;
            UpdateUI();
            SceneManager.LoadScene("ResultScene");
            return;
        }

        UpdateUI();
    }

    public void ResetStats()
    {
        score = 0;
        hearts = 3;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (heartImages != null)
        {
            for (int i = 0; i < heartImages.Length; i++)
            {
                if (heartImages[i] != null)
                    heartImages[i].enabled = i < hearts;
            }
        }
    }
}
