using UnityEngine;

public class Chain : MonoBehaviour
{
    private Animator myAnim;
    private const string CHAIN_RESET = "chain_reset";
    private Vector3 defaultChainPosition;
    private void Awake()
    {
        myAnim = GetComponent<Animator>();
        defaultChainPosition = transform.position;
    }

    private void Start()
    {
        GameManager.Instance.OnGuessMade += GameManager_OnGuessMade;
    }

    private void GameManager_OnGuessMade(object sender, GameManager.OnGuessMadeEventArgs e)
    {
        ResetChainPositions();
    }

    public void ResetChainPositions()
    {
        myAnim.SetTrigger(CHAIN_RESET);
        transform.position = defaultChainPosition;
    }

}
