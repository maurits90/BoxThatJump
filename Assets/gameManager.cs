using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public GameObject gameStartCanvas;
    public GameObject gameOverCanvas;
    public GameObject gameScoreCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        gameStartCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            gameStart();
        }
    }

    public void gameStart()
    {
        gameStartCanvas.SetActive(false);
        gameScoreCanvas.SetActive(true);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
