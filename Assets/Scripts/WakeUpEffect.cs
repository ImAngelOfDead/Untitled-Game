using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WakeUpEffect : MonoBehaviour
{
    public Image blackoutImage; 
    public float fadeDuration = 1.0f; 

    void Start()
    {
        StartCoroutine(WakeUpSequence());
    }

    IEnumerator WakeUpSequence()
    {
        // Эффект моргания
        yield return StartCoroutine(BlinkEffect());
    }

    IEnumerator BlinkEffect()
    {
        
        Color imageColor = blackoutImage.color;
        imageColor.a = 1.0f;
        blackoutImage.color = imageColor;
        
        
        
        float timeElapsed = 0;
        while (timeElapsed < fadeDuration)
        {
            imageColor.a = Mathf.Lerp(1.0f, 0.0f, timeElapsed / fadeDuration);
            blackoutImage.color = imageColor;
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        imageColor.a = 0.0f;
        blackoutImage.color = imageColor;
    }

}
