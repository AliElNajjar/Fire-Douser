using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public Text scoreText;
    public AudioSource cam;
    public AudioClip gameOver;

    private void OnEnable()
    {
        scoreText.text = ScoreController.score.ToString();
        cam.PlayOneShot(gameOver);
        
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
