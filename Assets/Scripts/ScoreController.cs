using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController SharedInstance;

    public Text scoreLabel;
    private int currentScore = 0;
    public static int score;
    public Text livesLabel;
    private int currentLives = 5;
    public static bool GameIsOver;
    public GameObject gameOverUI;

    void Awake()
    {
        SharedInstance = this;
    }


    private void Start()
    {
        GameIsOver = false;
        score = 0;
    }


    private void Update()
    {
        if (GameIsOver)
            return;
        if (currentLives <=0)
        {
            EndGame();
        }
    }
    public void IncrementScore(int increment)
    {
        currentScore += increment;
        score += increment;
        scoreLabel.text = "Score: " + currentScore.ToString();
    }

    public void DecrementLife(int decrement)
    {
        currentLives -= decrement;
        livesLabel.text = "Lives: " + currentLives.ToString();
    }

    public void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);

    }
}
