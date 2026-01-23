using UnityEngine;

public class GuessTemplate : MonoBehaviour
{
    [SerializeField] private GameObject iconImagePrefab;
    private bool once = false;

    private void Start()
    {
        GameManager.Instance.OnGuessMade += GameManager_OnGuessMade;
    }

    private void GameManager_OnGuessMade(object sender, GameManager.OnGuessMadeEventArgs e)
    {
        if(!once)
        {
            once = true;
            for (int i = 0; i < e.correctAmountOfNumbersInPatternGuessed; i++)
            {
                Instantiate(iconImagePrefab, transform);
            }
        }
        
    }
}
