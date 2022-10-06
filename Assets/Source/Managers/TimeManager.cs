using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{

    public float timePerRound = 10f;
    private float timer;
    public TextMeshProUGUI textUI;

    private GameManager gameManager;
    void Start()
    {
        this.gameManager = GetComponent<GameManager>();
        timer = timePerRound;
    }

    void Update()
    {
        if (!gameManager.GameRunning)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            textUI.text = "0";
            gameManager.OnTimerOut();
            timer = timePerRound;
        }
        else
        {
            textUI.text = timer.ToString("00.00");
        }


    }


}
