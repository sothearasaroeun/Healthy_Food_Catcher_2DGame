using UnityEngine;
using System.Collections;

public enum Difficulty { Easy, Normal, Hard }

public class FoodSpawner : MonoBehaviour
{
    [Header("Food Prefabs")]
    public GameObject[] healthyFoods;
    public GameObject[] junkFoods;

    [Header("UI Parent")]
    public RectTransform parent;

    [Header("Difficulty")]
    public Difficulty difficulty = Difficulty.Normal;

    [Header("Spawn Timing")]
    public float spawnIntervalMin;
    public float spawnIntervalMax;
    public float minSpawnLimit = 0.6f;
    public float spawnDecreaseRate = 0.03f;

    [Header("Fall Speed")]
    public float fallSpeedStart = 120f;
    public float fallSpeedIncrease = 4f;
    public float maxFallSpeed = 320f;

    [Header("Spawn Position")]
    public float spawnOffsetY = 80f;
    public float horizontalPadding = 100f;

    float currentFallSpeed;
    RectTransform canvasRect;

    void Start()
    {
        canvasRect = parent.GetComponentInParent<Canvas>().GetComponent<RectTransform>();

        ApplyDifficulty();                 // Difficulty sets START values
        currentFallSpeed = fallSpeedStart;

        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            float waitTime = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(waitTime);

            SpawnOneFood();
            IncreaseDifficultyOverTime();  // 🔥 Always scales
        }
    }

    void SpawnOneFood()
    {
        bool spawnHealthy = Random.value > 0.5f;

        GameObject prefab = spawnHealthy
            ? healthyFoods[Random.Range(0, healthyFoods.Length)]
            : junkFoods[Random.Range(0, junkFoods.Length)];

        float randomX = Random.Range(
            -canvasRect.rect.width / 2 + horizontalPadding,
             canvasRect.rect.width / 2 - horizontalPadding
        );

        Vector2 spawnPos = new Vector2(
            randomX,
            canvasRect.rect.height / 2 + spawnOffsetY
        );

        GameObject food = Instantiate(prefab, parent);
        food.GetComponent<RectTransform>().anchoredPosition = spawnPos;

        FoodFall fall = food.GetComponent<FoodFall>();
        fall.fallSpeed = currentFallSpeed;
    }

    void IncreaseDifficultyOverTime()
    {
        // ⏱ Spawn faster (lower interval)
        spawnIntervalMin = Mathf.Max(minSpawnLimit, spawnIntervalMin - spawnDecreaseRate);
        spawnIntervalMax = Mathf.Max(minSpawnLimit + 0.3f, spawnIntervalMax - spawnDecreaseRate);

        // ⬇ Food falls faster
        currentFallSpeed = Mathf.Min(
            maxFallSpeed,
            currentFallSpeed + fallSpeedIncrease
        );
    }

    void ApplyDifficulty()
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                spawnIntervalMin = 1.8f;
                spawnIntervalMax = 2.8f;
                fallSpeedStart = 90f;
                spawnDecreaseRate = 0.02f;
                fallSpeedIncrease = 3f;
                break;

            case Difficulty.Normal:
                spawnIntervalMin = 1.2f;
                spawnIntervalMax = 2.2f;
                fallSpeedStart = 120f;
                spawnDecreaseRate = 0.03f;
                fallSpeedIncrease = 4f;
                break;

            case Difficulty.Hard:
                spawnIntervalMin = 0.8f;
                spawnIntervalMax = 1.4f;
                fallSpeedStart = 150f;
                spawnDecreaseRate = 0.05f;
                fallSpeedIncrease = 6f;
                break;
        }
    }
}
