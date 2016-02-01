using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Paddle : MonoBehaviour
{
    public static Paddle paddle;
    public float speed = 1f;

    public Vector2 bounceAngle;
    float xBound = 4.62f;

    float input;

    float delta = Mathf.PI / 8f;

    Rigidbody2D rb2d;

    public bool allowedToMove = true;
    void Awake()
    {
        if (paddle == null)
        {
            paddle = this;
        }
        else if (paddle != this)
        {
            Destroy(gameObject);
        }
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
       if (allowedToMove) rb2d.MovePosition(new Vector2(Mathf.Clamp(rb2d.position.x + input*speed*Time.deltaTime, -xBound, xBound), rb2d.position.y));
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        //determine where on the paddle the ball hits
        Debug.Log("Ball is at: " + Ball.ball.transform.position + "\nPaddle is at: " + transform.position);
        float distance = Mathf.Abs(transform.position.x - Ball.ball.transform.position.x);
        Debug.Log("Distance between ball and center of paddle: " + distance);

        float theta = Mathf.PI / 2f;

        if (transform.position.x - Ball.ball.transform.position.x > 0) theta += delta;
        else theta -= delta;

        bounceAngle = new Vector2(Mathf.Cos(theta)*speed, Mathf.Sin(theta)*speed);
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(bounceAngle, ForceMode2D.Impulse);
    }
}
