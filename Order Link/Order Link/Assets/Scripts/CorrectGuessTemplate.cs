using UnityEngine;

public class CorrectGuessTemplate : MonoBehaviour
{
    [SerializeField] private GameObject correctIconImagePrefab;
    bool once = false;

    private void Start()
    {
        GameManager.Instance.OnGuessMade += GameManager_OnGuessMade;
    }

    private void GameManager_OnGuessMade(object sender, GameManager.OnGuessMadeEventArgs e)
    {
        if(!once)
        {
            once = true;
            for(int i=0; i<e.numberOfCorrectGuess;i++)
            {
                Instantiate(correctIconImagePrefab, transform);
            }
        }
    }
}
