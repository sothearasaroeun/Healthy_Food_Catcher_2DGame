using UnityEngine;

public class Food : MonoBehaviour
{
    public bool isHealthy;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered with: " + other.name);

        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Player caught food!");

        if (isHealthy)
        {
            Debug.Log("Healthy food caught");
            GameManager.instance.OnHealthyFoodCaught();
        }
        else
        {
            Debug.Log("Junk food caught");
            GameManager.instance.OnJunkFoodCaught();
        }

        Destroy(gameObject);
    }
}
