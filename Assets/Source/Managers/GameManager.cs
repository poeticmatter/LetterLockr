using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool gameRunning = false;

    public bool GameRunning { get { return gameRunning; } }
    private WordManager wordManager;
    private LockManager lockManager;
    private ScoreManager scoreManager;
    public TextMeshProUGUI gameOverTextUI;
    public TextMeshProUGUI instructionTextUI;
    [TextArea]
    public string startText;
    [TextArea]
    public string gameOverText;
    void Start()
    {
        wordManager = GetComponent<WordManager>();
        lockManager = GetComponent<LockManager>();
        scoreManager = GetComponent<ScoreManager>();
        gameOverTextUI.text = startText;
        gameOverTextUI.enabled = true;
    }

    void Update()
    {
        if (gameRunning == false && Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();

        }
    }

    public void OnTimerOut()
    {
        if (scoreManager.ScoreLeft > 0)
        {
            NextLevel();
        }
        else
        {
            GameOver();
        }
    }

    public void OnWordScore()
    {
        scoreManager.OnWordScore();
        instructionTextUI.enabled = false;
    }

    private void NextLevel()
    {
        scoreManager.OnShiftScore();
        lockManager.RandomizeLock();
        wordManager.ResetInput();
    }

    private void GameOver()
    {
        gameRunning = false;
        gameOverTextUI.text = gameOverText;
        gameOverTextUI.enabled = true;

    }

    private void RestartGame()
    {
        gameRunning = true;
        wordManager.Restart();
        gameOverTextUI.enabled = false;
        scoreManager.ResetScores();
    }

}
