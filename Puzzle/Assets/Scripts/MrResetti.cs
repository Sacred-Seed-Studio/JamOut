using UnityEngine;
using System.Collections;

public class MrResetti : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameController.controller.lives > 0)
        {
            Ball.ball.ResetBall();
            GameController.controller.lives -= 1;
        }
        else
        {
            GameController.controller.GameOver();
        }
    }

}
