using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private List<int> patternList;
    private List<int> collectionsArray;
    private List<int> playerGuessPatternList;

    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    [SerializeField] private Button button4;
    [SerializeField] private Button button5;
    [SerializeField] private Button button6;

    private int numberOfCorrectGuesses;
    private int correctAmountOfNumbersInPattern;
    private int numberOfTurns;
    private bool once = false;

    public event EventHandler<OnGuessMadeEventArgs> OnGuessMade;
    public class OnGuessMadeEventArgs : EventArgs
    {
        public List<int> playerPatternList;
    }

    private void Awake()
    {
        Instance = this;
        patternList = new List<int>();
        collectionsArray = new List<int>();
        playerGuessPatternList = new List<int>();
        AssignCollection();
        if (collectionsArray.Count > 0)
        {
            AssignPattern(4);
        }

        button1.onClick.AddListener(() =>
        {
            playerGuessPatternList.Add(1);
            NumbersCheck(1);
            button1.gameObject.SetActive(false);
        });
        button2.onClick.AddListener(() =>
        {
            playerGuessPatternList.Add(2);
            NumbersCheck(2);
            button2.gameObject.SetActive(false);
        });
        button3.onClick.AddListener(() =>
        {
            playerGuessPatternList.Add(3);
            NumbersCheck(3);
            button3.gameObject.SetActive(false);
        });
        button4.onClick.AddListener(() =>
        {
            playerGuessPatternList.Add(4);
            NumbersCheck(4);
            button4.gameObject.SetActive(false);
        });
        button5.onClick.AddListener(() =>
        {
            playerGuessPatternList.Add(5);
            NumbersCheck(5);
            button5.gameObject.SetActive(false);
        });
        button6.onClick.AddListener(() =>
        {
            playerGuessPatternList.Add(6);
            NumbersCheck(6);
            button6.gameObject.SetActive(false);
        });
    }

    private void AssignCollection()
    {
        for(int i=1;i<=6;i++)
        {
            collectionsArray.Add(i);
        }
    }

    private int ReturnRandomNumberFromCollection()
    {
        int index = UnityEngine.Random.Range(0, collectionsArray.Count);
        int randomNumber = collectionsArray[index];
        collectionsArray.Remove(randomNumber);
        return randomNumber;
    }

    private void AssignPattern(int patternLength)
    {
        for(int i=0;i<patternLength;i++)
        {
            patternList.Add(ReturnRandomNumberFromCollection());
        }
    }

    private void Start()
    {

        if(patternList.Count >0)
        {
            foreach(int i in patternList)
            {
                Debug.Log(i);
            }
        }
    }

    private void PatternCheck()
    {
        OnGuessMade?.Invoke(this, new OnGuessMadeEventArgs
        {
            playerPatternList = playerGuessPatternList
        });
        for(int i=0;i<patternList.Count;i++)
        {
            if (patternList[i]  == playerGuessPatternList[i])
            {
                numberOfCorrectGuesses++;
            }
        }
        Debug.Log("Number of correct guesses = " + numberOfCorrectGuesses);
        Debug.Log("Number of correct numbers in pattern = " + correctAmountOfNumbersInPattern);
        if(numberOfCorrectGuesses == patternList.Count)
        {
            Debug.Log("You Win!");
        }
        else
        {
            ClearAllNumbersAndPatterns();
        }
        
    }

    private void NumbersCheck(int numberBeingAdded)
    {
        if(patternList.Contains(numberBeingAdded))
        {
            correctAmountOfNumbersInPattern++;
        }
    }

    private void ClearAllNumbersAndPatterns()
    {
        once = false;
        playerGuessPatternList.Clear();
        correctAmountOfNumbersInPattern = 0;
        numberOfCorrectGuesses = 0;
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
        button4.gameObject.SetActive(true);
        button5.gameObject.SetActive(true);
        button6.gameObject.SetActive(true);
    }
    private void Update()
    {
        if(playerGuessPatternList.Count == patternList.Count && !once)
        {
            once = true;
            button1.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            PatternCheck();
        }
    }
}
