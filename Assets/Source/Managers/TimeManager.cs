using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{

    private double timer = 10f;
    public TextMeshProUGUI textUI;

    private GameManager gameManager;
    void Start()
    {
        this.gameManager = GetComponent<GameManager>();
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
            timer = 10f;
        }
        else
        {
            textUI.text = timer.ToString("00.00");
        }


    }


}
