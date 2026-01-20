using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private AudioSource myAudio;
    [SerializeField] private Slider musicVolumeSlider;

    private void Awake()
    {
        myAudio = GetComponent<AudioSource>();
        ManageSingleton();
    }
    void ManageSingleton()
    {
        int instance = FindObjectsByType<MusicManager>(FindObjectsSortMode.None).Length;

        if(instance > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetVolume()
    {
        myAudio.volume = musicVolumeSlider.value;
    }
}
