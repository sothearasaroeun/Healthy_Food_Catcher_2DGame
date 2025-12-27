using UnityEngine;

public class Basket : MonoBehaviour
{
    private RectTransform basketRect;

    private void Awake()
    {
        basketRect = GetComponent<RectTransform>();

        if (basketRect == null)
            Debug.LogError("Basket must be a UI Image with RectTransform!");
    }

    private void Update()
    {
        if (basketRect == null) return;

        CheckFoodWithTag("Healthy");
        CheckFoodWithTag("Junk");
    }

    void CheckFoodWithTag(string tag)
    {
        GameObject[] foods = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject food in foods)
        {
            if (food == null) continue;

            RectTransform foodRect = food.GetComponent<RectTransform>();
            if (foodRect == null) continue;

            if (IsOverlapping(basketRect, foodRect))
            {
                if (GameManager.Instance != null)
                {
                    if (tag == "Healthy")
                        GameManager.Instance.AddScore(1);
                    else if (tag == "Junk")
                        GameManager.Instance.LoseHeart();
                }

                Destroy(food);
                break; // prevent double trigger
            }
        }
    }

    bool IsOverlapping(RectTransform a, RectTransform b)
    {
        Rect rectA = GetWorldRect(a);
        Rect rectB = GetWorldRect(b);
        return rectA.Overlaps(rectB);
    }

    Rect GetWorldRect(RectTransform rt)
    {
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        return new Rect(
            corners[0].x,
            corners[0].y,
            corners[2].x - corners[0].x,
            corners[2].y - corners[0].y
        );
    }
}
