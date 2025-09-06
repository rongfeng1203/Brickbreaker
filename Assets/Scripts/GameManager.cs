using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int totalScore;
    private int brickCount;
    private int brickScore = 50;
    public TMP_Text scoreText;

    public enum GameState
    {
        Game,
        Playing,
        Win,
        Lose
    }
    public GameState state;

    void Start()
    {
        state = GameState.Game;
        totalScore = 0;
        brickCount = GameObject.FindGameObjectsWithTag("Brick").Length;
    }
    void Update()
    {
        if (state == GameState.Playing)
        {
            CheckWin();
        }
    }

    public void AddBrickCount()
    {
        brickCount += 1;
    }

    public void SubtractBrickCount()
    {
        brickCount -= 1;
    }

    public void DestroyBall(GameObject ball)
    {
        Destroy(ball);
        state = GameState.Lose;
    }

    public void CheckWin()
    {
        if (brickCount <= 0)
        {
            state = GameState.Win;
        }
    }

    public void AddScore()
    {
        totalScore += brickScore;
        scoreText.text = "Score: " + totalScore.ToString();
    }

    public int GetScore()
    {
        return totalScore;
    }
}
