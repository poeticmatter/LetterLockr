using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreLeftTextUI;
    public TextMeshProUGUI scoreRightTextUI;
    public TextMeshProUGUI scoreTotalTextUI;

    private int scoreLeft = 0;
    private int scoreRight = 0;
    private int scoretotal = 0;

    public int ScoreTotal { get { return scoretotal; } }

    public int ScoreLeft { get { return scoreLeft; } }


    public void OnWordScore()
    {
        scoreLeft += 1;
        scoretotal = scoretotal + (scoreLeft * scoreRight);
        UpdateUI();
    }

    public void OnShiftScore()
    {
        scoreRight = scoreLeft;
        scoreLeft = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreLeftTextUI.text = scoreLeft.ToString();
        scoreTotalTextUI.text = scoretotal.ToString();
        scoreRightTextUI.text = scoreRight.ToString();
    }

    public void ResetScores()
    {
        scoreLeft = 0;
        scoreRight = 0;
        scoretotal = 0;
        UpdateUI();
    }
}
