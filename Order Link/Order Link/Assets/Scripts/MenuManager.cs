using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private TMP_Text titleText;

    private void Awake()
    {
        backButton.onClick.AddListener(() =>
        {
            optionsPanel.SetActive(false);
            titleText.gameObject.SetActive(true);
            playButton.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
            optionsButton.gameObject.SetActive(true);
        });

        optionsButton.onClick.AddListener(() => 
        {
            optionsPanel.SetActive(true);
            playButton.gameObject.SetActive(false);
            titleText.gameObject.SetActive(false);
            exitButton.gameObject.SetActive(false);
            optionsButton.gameObject.SetActive(false);
        });

        playButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        exitButton.onClick.AddListener(() => 
        {
            Application.Quit();
        });
    }

}
