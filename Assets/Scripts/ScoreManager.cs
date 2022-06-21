using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;

    public int highscore = 0;

    private GameManager gameManager;
    public UIManager uiManager;

    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        GameData.LoadData();
        highscore = GameData.levelHighscores[gameManager.levelIndex];
        uiManager.UpdateScoreText(score, highscore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Hit(Brick brick)
    {
        score += brick.points;
        if(score > highscore)
        {
            highscore = score;
        }
        uiManager.UpdateScoreText(score, highscore);

        if (gameManager.Cleared())
        {
            GameData.levelHighscores[gameManager.levelIndex] = highscore;
            GameData.SaveHighscore();
        }
    }
}
