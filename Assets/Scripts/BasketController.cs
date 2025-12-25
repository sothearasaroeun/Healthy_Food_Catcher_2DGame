using UnityEngine;

public class MoveUIImage : MonoBehaviour
{
    RectTransform rectTransform;

    public float moveDistance = 200f;   // Speed
    public float smoothSpeed = 8f;      // Smooth movement

    Vector2 targetPosition;
    float fixedY;   // Lock Y position

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        targetPosition = rectTransform.anchoredPosition;
        fixedY = targetPosition.y;   // Store initial Y
    }

    void Update()
    {
        HandleInput();

        // Smooth movement
        rectTransform.anchoredPosition = Vector2.Lerp(
            rectTransform.anchoredPosition,
            targetPosition,
            Time.deltaTime * smoothSpeed
        );
    }

    void HandleInput()
    {
        float moveX = 0f;

        // Keyboard input (A/D or Left/Right)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            moveX = -1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            moveX = 1f;

        if (moveX != 0f)
        {
            targetPosition += new Vector2(moveX, 0f) * moveDistance * Time.deltaTime;
            ClampToScreen();
        }
    }

    void ClampToScreen()
    {
        Canvas canvas = GetComponentInParent<Canvas>();
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();

        float canvasWidth = canvasRect.rect.width;
        float imageWidth = rectTransform.rect.width;

        float minX = -canvasWidth / 2 + imageWidth / 2;
        float maxX = canvasWidth / 2 - imageWidth / 2;

        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
        targetPosition.y = fixedY;   // Keep Y locked
    }
}
