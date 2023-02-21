using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float grondWidth;
    float obstacleWidth;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box=GetComponent<BoxCollider2D>();
            grondWidth=box.size.x;
        }

        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWidth= GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector2(transform.position.x - speed*Time.deltaTime, transform.position.y);

        if(gameObject.CompareTag("Ground"))
        {
         if(transform.position.x<= -grondWidth)
         {
           transform.position=new Vector2 (transform.position.x + 2 * grondWidth , transform.position.y);
         }           
        }

        else if (gameObject.CompareTag("Obstacle"))    
        {
            if(true)
            {
                Destroy(gameObject);

            }
        }



    }


}