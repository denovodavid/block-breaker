using UnityEngine;

public class Bounds : MonoBehaviour
{
    private Camera _Camera;
    private Ball _Ball;

    void Start()
    {
        _Camera = FindObjectOfType<Camera>();
        _Ball = FindObjectOfType<Ball>();

        Vector3 bottomLeftPos = _Camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightPos = _Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float BoundHeight = topRightPos.y - bottomLeftPos.y;
        float BoundWidth = topRightPos.x - bottomLeftPos.x;
        Vector2 BoundMiddle = new Vector2((bottomLeftPos.x + topRightPos.x) / 2, (bottomLeftPos.y + topRightPos.y) / 2);

        BoxCollider2D LeftBound = gameObject.AddComponent<BoxCollider2D>();
        BoxCollider2D RightBound = gameObject.AddComponent<BoxCollider2D>();
        BoxCollider2D UpperBound = gameObject.AddComponent<BoxCollider2D>();

        LeftBound.size = new Vector2(1, BoundHeight);
        LeftBound.offset = new Vector2(bottomLeftPos.x - (LeftBound.size.x / 2), BoundMiddle.y);

        RightBound.size = new Vector2(1, BoundHeight);
        RightBound.offset = new Vector2(topRightPos.x + (RightBound.size.x / 2), BoundMiddle.y);

        UpperBound.size = new Vector2(BoundWidth + 2, 1);
        UpperBound.offset = new Vector2(BoundMiddle.x, topRightPos.y + (UpperBound.size.y / 2));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == _Ball.tag)
        {
            // TODO: Play bip sound effect.
        }
    }

}
