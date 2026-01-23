using System.Collections.Generic;
using System;
using UnityEngine;

public class PatternHolder : MonoBehaviour
{
    public static PatternHolder Instance;
    [SerializeField] private GameObject patternTempatePrefab;

    public event EventHandler<OnPatternTemplateInstantiatedEventArgs> OnPatternTemplateInstantiated;
    public class OnPatternTemplateInstantiatedEventArgs : EventArgs
    {
        public GameObject activePatternTemplate;
        public List<int> currentGuessPattern;
        public int correctAmountOfNumbersGuessed;
        public int numberOfCorrectGuesses;
    }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        GameManager.Instance.OnGuessMade += GameManager_OnGuessMade;
    }

    private void GameManager_OnGuessMade(object sender, GameManager.OnGuessMadeEventArgs e)
    {
        GameObject currentPatternTemplate = Instantiate(patternTempatePrefab,transform);
        OnPatternTemplateInstantiated?.Invoke(this, new OnPatternTemplateInstantiatedEventArgs
        {
            activePatternTemplate = currentPatternTemplate,
            currentGuessPattern = e.playerPatternList,
            correctAmountOfNumbersGuessed = e.correctAmountOfNumbersInPatternGuessed,
            numberOfCorrectGuesses = e.numberOfCorrectGuess
        });
        
    }
}
