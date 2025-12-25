using UnityEngine;

public class FoodFall : MonoBehaviour
{
    public float fallSpeed;

    RectTransform rect;
    RectTransform canvasRect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
        canvasRect = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.anchoredPosition -= Vector2.up * fallSpeed * Time.deltaTime;

        if (rect.anchoredPosition.y < -canvasRect.rect.height / 2 - 120f)
        {
            Destroy(gameObject);
        }
    }
}
