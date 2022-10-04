using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{

    private double timer = 9.9f;
    public TextMeshProUGUI textUI;

    private GameManager gameManager;
    void Start()
    {
        this.gameManager = GetComponent<GameManager>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameManager.OnTimerOut();
            timer = 9.9f;
        }
        textUI.text = timer.ToString("F1");
    }


}
