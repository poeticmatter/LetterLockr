using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameRunning = true;

    public bool GameRunning { get { return gameRunning; } }
    private WordManager wordManager;
    private LockManager lockManager;
    private ScoreManager scoreManager;
    void Start()
    {
        wordManager = GetComponent<WordManager>();
        lockManager = GetComponent<LockManager>();
        scoreManager = GetComponent<ScoreManager>();
    }

    public void OnTimerOut()
    {
        if (scoreManager.ScoreLeft > 0)
        {
            scoreManager.OnShiftScore();
            lockManager.RandomizeLock();
            wordManager.ResetWord();
        }
        else
        {
            gameRunning = false;
        }
    }

    public void OnWordScore()
    {
        scoreManager.OnWordScore();
    }

}
