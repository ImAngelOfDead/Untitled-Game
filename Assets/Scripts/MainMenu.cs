using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;
    public AudioClip[] audioClips; 
    public Button resetButton; 

    void Start()
    {
        if (audioSource != null)
        {
            audioSource.volume = 0.1f; 
            volumeSlider.value = audioSource.volume;

            volumeSlider.onValueChanged.AddListener(SetVolume);
            PlayRandomClip();

            if (resetButton != null)
            {
                resetButton.onClick.AddListener(OnResetButtonClicked);
            }
            else
            {
                Debug.LogError("ResetButton is not assigned.");
            }
        }
        else
        {
            Debug.LogError("AudioSource is not assigned.");
        }
    }

    void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }

    public void PlayRandomClip()
    {
        if (audioClips.Length > 0)
        {
            int randomIndex = Random.Range(0, audioClips.Length);
            audioSource.clip = audioClips[randomIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No audio clips assigned.");
        }
    }

    void OnResetButtonClicked()
    {
        PlayRandomClip(); // Воспроизводим новый случайный трек
    }
}
