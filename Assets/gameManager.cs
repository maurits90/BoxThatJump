using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public GameObject gameScoreCanvas;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
    }

    public void gameStart()
    {
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
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
