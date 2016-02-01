using UnityEngine;
using System.Collections;

public class GameBrick : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
