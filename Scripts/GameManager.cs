using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    public static bool GameOver;
    
    public GameObject gameOverUi;
    public GameObject winGameUi;

    private void Start()
    {
        GameOver = false;
    }

    void Update()
    {
        if (GameOver)
            return;

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }


        if (Input.GetKeyDown("q"))
        {
            WinGame();
        }


        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        GameOver = true;
        gameOverUi.SetActive(true);
    }

    public void WinGame()
    {
        GameOver = true;
        winGameUi.SetActive(true);
    }
}
