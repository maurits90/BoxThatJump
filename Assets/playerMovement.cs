using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{
    public gameManager gm;
    public enemyScript es;
    public enemySpawner eSpawn;
    Rigidbody2D rb;
    public float jumpHeight;
    bool onGround;

    float score;

    public Text scoretxt;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        scoretxt.text = "" + score;
        score += Time.deltaTime;
        if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {
            
            if(onGround == true)
            {
                rb.velocity = Vector2.up * jumpHeight;
                onGround = false;
            }
        }
        foreach(Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            { 
                if(onGround == true)
                {
                    rb.velocity = Vector2.up * jumpHeight;
                    onGround = false;
                }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        onGround = true;
        if(collision.gameObject.tag == "enemy")
        {
            gm.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "triggerScore")
        {
            es.addSpeed();
            eSpawn.addEnemy();

        }
    }
}
