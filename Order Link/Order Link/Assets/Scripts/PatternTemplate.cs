using UnityEngine;
using TMPro;

public class PatternTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text chosenPatternText;

    private void Start()
    {
        chosenPatternText.text = "";
        GameManager.Instance.OnGuessMade += GameManager_OnGuessMade;
    }

    private void GameManager_OnGuessMade(object sender, GameManager.OnGuessMadeEventArgs e)
    {
        chosenPatternText.text = "";
        foreach (int i in e.playerPatternList)
        {
            chosenPatternText.text += i.ToString();
        }
    }
}
