using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] private float _speed;
    int angle;
    int maxAngle= 20;
    int minAngle=-60;
    public Score score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    void Start()
    {
        _rb=GetComponent<Rigidbody2D>();
        _rb.gravityScale=0;
        sp=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();

       
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
        
    }

    private void FixedUpdate() 
    {
        FishRotation();
    }

    void FishSwim()
    {
        if(Input.GetMouseButton(0) && GameManager.gameOver==false)
        {
            if(GameManager.gameStarted==false)
            {
                _rb.gravityScale= 1.8f;
                _rb.velocity=Vector2.zero;
                _rb.velocity=new Vector2(_rb.velocity.x,_speed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity=Vector2.zero;
                _rb.velocity=new Vector2(_rb.velocity.x,_speed);
            }
            
            
        }
    }

    void FishRotation()
    {
        if(_rb.velocity.y>0)
        {
            if(angle<=maxAngle)
            {
                angle= angle +4;
            }
        }

        else if (_rb.velocity.y<-1.2)
        {
            if(angle>minAngle)
            {
                angle=angle -2;
            }
        }

        if(touchedGround==false)
        {
            transform.rotation=Quaternion.Euler(0,0,angle);
        }

    }
    

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Obstacle"))
        {
            score.Scored();
        }

        else if (other.CompareTag("Column"))
        {
            gameManager.GameOver();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            if(GameManager.gameOver==false)
            {
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        touchedGround=true;
        transform.rotation=Quaternion.Euler(0,0,-90);
        sp.sprite=fishDied;
        anim.enabled=false;

    }
}


