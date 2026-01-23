using UnityEngine;
using TMPro;

public class PatternTemplate : MonoBehaviour
{
    [SerializeField] private TMP_Text chosenPatternText;
    private bool once = false;

    private void Start()
    {
        chosenPatternText.text = "";
        PatternHolder.Instance.OnPatternTemplateInstantiated += PatternHolder_OnPatternTemplateInstantiated;
    }

    private void PatternHolder_OnPatternTemplateInstantiated(object sender, PatternHolder.OnPatternTemplateInstantiatedEventArgs e)
    {
        if(!once)
        {
            once = true;
            foreach (int i in e.currentGuessPattern)
            {
                chosenPatternText.text += i.ToString();
            }
        }
        
    }
}
