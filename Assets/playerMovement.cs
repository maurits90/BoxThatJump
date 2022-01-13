using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public gameManager gm;
    public AudioScript sound;
    Rigidbody2D rb;
    public float jumpHeight;
    bool onGround;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    float score;

    public Text scoretxt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "" + score.ToString("F0");
        score += Time.deltaTime;
        Jump();
        BetterJump();
    }

    void Jump()
    {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {

            if (onGround == true)
            {
                rb.velocity = Vector2.up * jumpHeight;
                onGround = false;
                sound.playJump();
            }
        }
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                if (onGround == true)
                {
                    rb.velocity = Vector2.up * jumpHeight;
                    onGround = false;
                    sound.playJump();
                }
            }
        }
    }

    void BetterJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        foreach (Touch touch in Input.touches)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 9)* Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && touch.phase != TouchPhase.Began)
            {
                rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 2) * Time.deltaTime;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        if(collision.gameObject.tag == "enemy")
        {
            sound.playGameOver();
            gm.GameOver();
        }
    }
}
