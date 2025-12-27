using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] foods;      // UI food prefabs
    public RectTransform canvas;    // Canvas parent
    public float spawnRate = 1.5f;
    public float xRange = 500f;     // UI units (pixels)

    void Start()
    {
        InvokeRepeating(nameof(SpawnFood), 1f, spawnRate);
    }

    void SpawnFood()
    {
        // Pick random food
        int index = Random.Range(0, foods.Length);

        // Instantiate UI object
        GameObject food = Instantiate(foods[index], canvas);

        // Set position using RectTransform
        RectTransform foodRect = food.GetComponent<RectTransform>();

        float randomX = Random.Range(-xRange, xRange);
        foodRect.anchoredPosition = new Vector2(randomX, 600f); // spawn from top
        foodRect.localScale = Vector3.one;
    }
}
