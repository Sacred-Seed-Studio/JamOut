using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController controller;
    public static int startingLives = 3;

    public int lives = 3;

    public GameObject gameOverMessage;

    public string[] winMessages = { "Awesome", "You Rock", "Good Job" };
    public string[] loseMessages = { "Game Over", "You Suck", "Try Again" };

    public AudioClip gameOver, win;

    AudioSource cameraAudio;
   [HideInInspector] public bool won = false;

    void Awake()
    {
        if (controller == null)
        {
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
        cameraAudio = Camera.main.GetComponent<AudioSource>();
    }

    public void GameOver()
    {
        Paddle.paddle.allowedToMove = false;
        Ball.ball.gameObject.SetActive(false);
        StartCoroutine(ShowMessage(loseMessages[Random.Range(0, loseMessages.Length)], gameOver));
    }

    public void Win()
    {
        won = true;
        Paddle.paddle.allowedToMove = false;
        Ball.ball.gameObject.SetActive(false);
        StartCoroutine(ShowMessage(winMessages[Random.Range(0, winMessages.Length)], win));
    }

    IEnumerator ShowMessage(string message, AudioClip c)
    {
        //display a message
        cameraAudio.loop = false;
        cameraAudio.clip = c;
        cameraAudio.Play();
        gameOverMessage.SetActive(true);
        gameOverMessage.GetComponentInChildren<Text>().text = message;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Main");
    }

}
