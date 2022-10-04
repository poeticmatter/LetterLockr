using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private WordManager wordManager;
    private LockManager lockManager;
    void Start()
    {
        wordManager = GetComponent<WordManager>();
        lockManager = GetComponent<LockManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTimerOut()
    {

    }
}
