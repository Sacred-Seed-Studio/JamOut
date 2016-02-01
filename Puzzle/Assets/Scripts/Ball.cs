using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{
    public static Ball ball;
    public float speed = 1f;

    Rigidbody2D rb2d;

    Vector2 origin;

    void Awake()
    {
        if (ball == null)
        {
            ball = this;
        }
        else if (ball != this)
        {
            Destroy(gameObject);
        }
        rb2d = GetComponent<Rigidbody2D>();
        origin = transform.position;
    }

    public void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = origin;
    }
}
