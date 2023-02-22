using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject getReady;

    public static bool gameStarted;
    public static int gameScore;
    public GameObject score;


    private void Awake() 
    {
        bottomLeft= Camera.main.ScreenToWorldPoint(new Vector2(0,0));
    }


    // Start is called before the first frame update
    void Start()
    {
        gameOver=false;
        gameStarted=false;

    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameHasStarted()
    {
        gameStarted=true;
        getReady.SetActive(false);

    }

    public void GameOver()
    {
        gameOver=true;
        gameOverPanel.SetActive(true);
        score.SetActive(false);
        gameScore = score.GetComponent<Score>().GetScore();
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
