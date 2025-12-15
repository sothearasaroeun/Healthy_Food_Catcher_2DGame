using UnityEngine;

public class FoodFall : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Destroy when off-screen
        if (transform.position.y < -6f)
            Destroy(gameObject);
    }
}
