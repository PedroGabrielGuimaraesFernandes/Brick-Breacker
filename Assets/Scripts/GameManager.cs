using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int lives = 3;

    public int levelIndex = 0;

    public UIManager uiManager { get; private set; }
    public PowerUpManager powerUpManager { get; private set; }

    private Vector3 initalBallPosition;
    private Vector3 initalPosition;

    private BallMovement ball; 
    private BarMovement paddle;
    private Brick[] bricks;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        uiManager.UpdateLivesUI(lives);
        powerUpManager = FindObjectOfType<PowerUpManager>();
        ball = FindObjectOfType<BallMovement>();
        paddle = FindObjectOfType<BarMovement>();
        bricks = FindObjectsOfType<Brick>();
        initalBallPosition = ball.gameObject.transform.position;
        //GameData.LoadData();
    }

    private void Update()
    {
        if (Cleared())
        {
            LevelClear();
        }
    }    

    public void GainALife()
    {
        lives++;
        uiManager.UpdateLivesUI(lives);
    }

    public void Miss()
    {
        lives--;
        if (lives > 0)
        {
            uiManager.UpdateLivesUI(lives);
            ball.ResetBall();
            paddle.ResetPaddle();
        }
        else
        {
            //Time.timeScale = 0;
            ball.StopBall();
            paddle.StopPaddle();
            uiManager.GameOver();
        }
    }

    private void LevelClear()
    {
        //Time.timeScale = 0;
        ball.StopBall();
        paddle.StopPaddle();
        if (levelIndex+1 < GameData.levelStatus.Length) {
            GameData.levelStatus[levelIndex + 1] = 1;
            GameData.SaveLevelStatus();
                }
        uiManager.Cleared();
    }

    public bool Cleared()
    {
        for (int i = 0; i < bricks.Length; i++)
        {
            if(bricks[i].gameObject.activeSelf && !bricks[i].unbreakable)
            {
                return false;
            }
        }

        return true;
    }
   
}
