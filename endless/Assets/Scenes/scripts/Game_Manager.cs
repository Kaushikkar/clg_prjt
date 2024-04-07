using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static int score = 0;
    public static int highScore = 0;

    private void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
    }

    private void Update()
    {
        if(score>highScore)
        {
            highScore=score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {


        Application.Quit();
    }
    public void HowToPlayMenu()
    {
        SceneManager.LoadScene(3);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetScore()
    {
        score = 0;
    }
}