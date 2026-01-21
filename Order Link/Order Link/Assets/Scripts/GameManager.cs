using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private List<int> patternList;
    private List<int> collectionsArray;
    private List<int> playerGuessPatternList;

    private void Awake()
    {
        patternList = new List<int>();
        collectionsArray = new List<int>();
        playerGuessPatternList = new List<int>();
        AssignCollection();
        if (collectionsArray.Count > 0)
        {
            AssignPattern(4);
        }
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
        int index = Random.Range(0, collectionsArray.Count);
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

    }
}
