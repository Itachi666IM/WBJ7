using UnityEngine;

public class GuessButton : MonoBehaviour
{
    private const string CHAIN_PULL = "chain_pull";
    [SerializeField] private GameObject chainLinked;
    private Animator chainAnim;

    private void Awake()
    {
        chainAnim = chainLinked.GetComponent<Animator>();
    }

    public void PerformChainPullAnimation()
    {
        chainAnim.SetTrigger(CHAIN_PULL);
    }
}
