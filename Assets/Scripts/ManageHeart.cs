using UnityEngine;
using UnityEngine.UI;

public class HeartUI : MonoBehaviour
{
    public Image[] hearts;
    public int currentHearts;

    void Start()
    {
        currentHearts = hearts.Length;
        UpdateHearts();
    }

    public void LoseHeart()
    {
        if (currentHearts <= 0) return;

        currentHearts--;
        UpdateHearts();
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = i < currentHearts;
        }
    }
}
