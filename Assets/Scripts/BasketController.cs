using UnityEngine;

public class BasketController : MonoBehaviour
{
    public float speed = 800f; // UI needs higher speed

    private RectTransform rectTransform;
    private float minX;
    private float maxX;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        float canvasWidth = rectTransform.root.GetComponent<RectTransform>().rect.width;
        float basketWidth = rectTransform.rect.width;

        // Calculate movement limits
        minX = -(canvasWidth / 2) + (basketWidth / 2);
        maxX = (canvasWidth / 2) - (basketWidth / 2);
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");

        Vector2 pos = rectTransform.anchoredPosition;
        pos.x += moveX * speed * Time.deltaTime;

        // Clamp inside screen
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rectTransform.anchoredPosition = pos;
    }
}
