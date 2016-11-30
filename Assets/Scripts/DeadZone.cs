using UnityEngine;

public class DeadZone : MonoBehaviour
{

    private Camera _Camera;
    private Ball _Ball;
    private LevelManager _LevelManager;
    public string OnTriggerLevel;

    void Start()
    {
        _Camera = FindObjectOfType<Camera>();
        _Ball = FindObjectOfType<Ball>();
        _LevelManager = FindObjectOfType<LevelManager>();

        Vector3 bottomLeftPos = _Camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRightPos = _Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        // float BoundHeight = topRightPos.y - bottomLeftPos.y;
        float BoundWidth = topRightPos.x - bottomLeftPos.x;
        Vector2 BoundMiddle = new Vector2((bottomLeftPos.x + topRightPos.x) / 2, (bottomLeftPos.y + topRightPos.y) / 2);

        BoxCollider2D DeadZone = gameObject.AddComponent<BoxCollider2D>();

        DeadZone.size = new Vector2(BoundWidth + 2, 1);
        DeadZone.offset = new Vector2(BoundMiddle.x, bottomLeftPos.y - (DeadZone.size.y / 2));
        DeadZone.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == _Ball.tag)
        {
            _LevelManager.LoadLevel(OnTriggerLevel);
        }
    }

}
