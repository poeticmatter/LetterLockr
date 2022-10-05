using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{
    public TextMeshProUGUI inputTextUI;
    public TextMeshProUGUI outputTextUI;

    private string currentText = "";
    private string lastScoredWord = "";
    private LockManager lockManager;
    private GameManager gameManager;
    public TextAsset wordListRaw;
    private HashSet<string> wordList;
    private HashSet<string> usedWords;

    private string[] wordArray;
    void Start()
    {
        this.lockManager = GetComponent<LockManager>();
        this.gameManager = GetComponent<GameManager>();
        this.wordArray = wordListRaw.text.Split('\n');
        wordList = new HashSet<string>(wordArray);
    }
    void Update()
    {
        if (!gameManager.GameRunning)
        {
            return;
        }
        currentText = inputTextUI.text;
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            OnBackspace();
        }
        else if (currentText.Length >= 5)
        {
            ValidateWord();
        }
        else
        {
            string input = GetInput();
            if (input.Length > 0)
            {
                OnInput(input);
            }
        }
        inputTextUI.text = currentText;
    }

    private void OnBackspace()
    {
        if (currentText.Length > 0)
        {
            currentText = currentText.Substring(0, inputTextUI.text.Length - 1);
        }
    }
    private void OnInput(string input)
    {
        currentText += input;
    }

    private void ValidateWord()
    {
        if (isChainedLetterMatched() && IsInWordList())
        {
            ScoreWord();
        }
    }

    public void ResetWord()
    {
        currentText = "";
        inputTextUI.text = "";
    }

    private void ScoreWord()
    {
        lastScoredWord = currentText;
        outputTextUI.text = currentText;
        currentText = "";
        inputTextUI.text = "";
        usedWords.Add(lastScoredWord);
        gameManager.OnWordScore();
    }

    public void Restart()
    {
        lastScoredWord = wordArray[Random.Range(0, wordList.Count)].ToUpper();
        outputTextUI.text = lastScoredWord;
        usedWords = new HashSet<string>();
        usedWords.Add(lastScoredWord);
    }

    private bool isChainedLetterMatched()
    {
        if (lastScoredWord.Length <= 0)
        {
            return true;
        }
        int lockIndex = lockManager.LockIndex;
        string lockedLetter = lastScoredWord.Substring(lockIndex, 1);
        string checkedLetter = currentText.Substring(lockIndex, 1);
        return lockedLetter == checkedLetter;
    }
    private bool IsInWordList()
    {
        return !usedWords.Contains(currentText) && wordList.Contains(currentText.ToLower());
    }

    private string GetInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return "A";
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            return "B";
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            return "C";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            return "D";
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            return "E";
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            return "F";
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            return "G";
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            return "H";
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            return "I";
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            return "J";
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            return "K";
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            return "L";
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            return "M";
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            return "N";
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            return "O";
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            return "P";
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            return "Q";
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            return "R";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            return "S";
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            return "T";
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            return "U";
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            return "V";
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            return "W";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            return "X";
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            return "Y";
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            return "Z";
        }

        return "";
    }
}
