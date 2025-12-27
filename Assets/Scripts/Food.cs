using UnityEngine;

public class Food : MonoBehaviour
{
    public float fallSpeed = 5f;

    private void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}
