using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool AutoPlay = false;
    private Camera _Camera;
    private Ball _Ball;

    private bool _BallAttached = true;
    private float _MinPosX;
    private float _MaxPosX;

    void Start()
    {
        _Camera = FindObjectOfType<Camera>();
        _Ball = FindObjectOfType<Ball>();
        _MinPosX = _Camera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        _MaxPosX = _Camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Update()
    {
        if (!AutoPlay)
        {
            Follow(_Camera.ScreenToWorldPoint(Input.mousePosition).x);
        }
        else
        {
            Follow(_Ball.transform.position.x);
        }

        if (_BallAttached)
        {
            float ballOffsetY = _Ball.GetComponent<Collider2D>().bounds.size.y / 2;
            float paddleOffsetY = GetComponent<Collider2D>().bounds.size.y / 2;
            _Ball.transform.position = new Vector3(transform.position.x, transform.position.y + paddleOffsetY + ballOffsetY, transform.position.z);

            if (Input.GetMouseButtonDown(0))
            {
                _BallAttached = false;
                _Ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 1), ForceMode2D.Impulse);
            }
        }
    }

    void Follow(float xPosition)
    {
        float paddleOffsetX = GetComponent<Collider2D>().bounds.size.x / 2;

        xPosition = Mathf.Clamp(xPosition, _MinPosX + paddleOffsetX, _MaxPosX - paddleOffsetX);

        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (!_BallAttached && other.gameObject.tag == _Ball.tag)
        {
            // TODO: Play boop sound effect.
        }
    }
}
