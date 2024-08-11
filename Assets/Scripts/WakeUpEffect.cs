using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WakeUpEffect : MonoBehaviour
{
    public Image blackoutImage; // Ссылка на UI-Image
    public float fadeDuration = 1.0f; // Длительность эффекта моргания
    public float headRaiseDuration = 2.0f; // Длительность подъема головы
    public float textDelay = 2.0f; // Задержка перед появлением текста
    public float textFadeDuration = 2.0f; // Длительность появления текста

    private Quaternion startRotation;
    private Quaternion endRotation;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public float liftHeight = 0.5f; // Насколько поднимется камера

    void Start()
    {
        StartCoroutine(WakeUpSequence());
    }

    IEnumerator WakeUpSequence()
    {
        // Эффект моргания
        yield return StartCoroutine(BlinkEffect());

        // Задержка перед затемнением и выводом текста
        //yield return new WaitForSeconds(textDelay);

        // Затемнение и вывод текста
        //yield return StartCoroutine(DisplayEndText());
    }

    IEnumerator BlinkEffect()
    {
        // Начальное значение прозрачности
        Color imageColor = blackoutImage.color;
        imageColor.a = 1.0f;
        blackoutImage.color = imageColor;
        
        
        // Плавное исчезновение черного экрана (1.0 -> 0.0)
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
