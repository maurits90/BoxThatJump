using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource jump;
    public AudioSource gameOver;

    public void playJump()
    {
        jump.Play();
    }

    public void playGameOver()
    {
        gameOver.Play();
    }
}
