using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown || Time.time > 3f)
        {
            SceneManager.LoadScene("Main");
        }
    }

}
