using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float speed;
    private float timer = 0;
    public float enemyDifficulty = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(timer > enemyDifficulty)
        {
            speed += 1;
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
