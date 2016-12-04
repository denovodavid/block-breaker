using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Speed;
    public float RandomBounce;
    private Rigidbody2D _Rigidbody2D;

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _Rigidbody2D.velocity = Speed * _Rigidbody2D.velocity.normalized;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-RandomBounce, RandomBounce), Random.Range(-RandomBounce, RandomBounce)), ForceMode2D.Impulse);
    }
}
