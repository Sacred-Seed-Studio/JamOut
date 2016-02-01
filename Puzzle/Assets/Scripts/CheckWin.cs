using UnityEngine;
using System.Collections;

public class CheckWin : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount == 0) GameController.controller.Win();
    }
}
