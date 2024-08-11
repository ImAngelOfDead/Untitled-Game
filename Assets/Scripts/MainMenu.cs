using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource; 

    void Start()
    {
        
        volumeSlider.value = audioSource.volume;

        
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    void SetVolume(float volume)
    {
        
        audioSource.volume = volume;
    }
}