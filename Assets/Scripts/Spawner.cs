using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] healthyFoods;
    public GameObject[] junkFoods;

    public float minX = -3f;
    public float maxX = 3f;
    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnFood());
    }

    System.Collections.IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));

            // Randomly choose type: 0 = healthy, 1 = junk
            bool spawnHealthy = (Random.value > 0.5f);

            GameObject prefabToSpawn;

            if (spawnHealthy)
                prefabToSpawn = healthyFoods[Random.Range(0, healthyFoods.Length)];
            else
                prefabToSpawn = junkFoods[Random.Range(0, junkFoods.Length)];

            // Pick random X position
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);

            Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
        }
    }
}
