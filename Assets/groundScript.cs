using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScript : MonoBehaviour
{
    public float speed;
    private float timer = 0;
    public float difficultyTimer = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position -= new Vector3(6 * Time.deltaTime, 0, 0);
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= -23.5)
        {
            transform.position = new Vector3(23.5f, transform.position.y,0f);
        }
        if(timer > difficultyTimer)
        {
            speed += 1;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
