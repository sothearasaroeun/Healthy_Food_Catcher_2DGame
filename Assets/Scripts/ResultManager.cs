using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public Text finalScoreText;
    public Text highScoreText;

    void Start()
    {
        int finalScore = GameManager.Instance != null
            ? GameManager.Instance.score
            : 0;

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (finalScore > highScore)
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }

        if (finalScoreText != null)
            finalScoreText.text = finalScore.ToString();

        if (highScoreText != null)
            highScoreText.text = highScore.ToString();
    }

}
