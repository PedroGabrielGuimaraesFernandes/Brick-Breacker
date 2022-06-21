using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    //public Image[] lives;
    public TextMeshProUGUI livesText;

    public GameObject gameoverPanel;
    public GameObject clearedPanel;

    public void UpdateScoreText(int scoreValue, int highscoreValue)
    {
        scoreText.text = "Score: " + scoreValue;
        highscoreText.text = "Highscore: " + highscoreValue;
    }

    public void UpdateLivesUI(int value)
    {
        livesText.text = "X " + value; 

        /*for (int i = 0; i < lives.Length; i++)
        {
            if(i <= value - 1)
            {
                lives[i].gameObject.SetActive(true);
            }
            else
            {
                lives[i].gameObject.SetActive(false);
            }
        }*/
    }

    public void GameOver()
    {
        gameoverPanel.SetActive(true);
    }

    public void Cleared()
    {
        clearedPanel.SetActive(true);
    }
}
