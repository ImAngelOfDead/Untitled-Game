using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource; 

    void Start()
    {
        
        if (audioSource != null)
        {
            
            audioSource.volume = 0.2f; 

            
            volumeSlider.value = audioSource.volume;
        }
        else
        {
            Debug.LogError("AudioSource is not assigned.");
        }

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        
        if (audioSource != null)
        {
            audioSource.volume = volume;
        }
    }
}
