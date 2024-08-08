using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WakeUpEffect : MonoBehaviour
{
    public Image blackoutImage; // Ссылка на UI-Image
    public float fadeDuration = 1.0f; // Длительность эффекта моргания
    public float headRaiseDuration = 2.0f; // Длительность подъема головы

    private Quaternion startRotation;
    private Quaternion endRotation;
    private Vector3 startPosition;
    private Vector3 endPosition;
    public float liftHeight = 0.5f; // Насколько поднимется камера

    void Start()
    {
        // Устанавливаем начальную и конечную ротацию камеры
        startRotation = Quaternion.Euler(-90, 0, 0);
        endRotation = Quaternion.Euler(0, 0, 0);

        // Начальное и конечное положение камеры
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(0, liftHeight, 0);

        // Устанавливаем начальное положение камеры
        transform.rotation = startRotation;

        // Начинаем процесс просыпания
        StartCoroutine(WakeUpSequence());
    }

    IEnumerator WakeUpSequence()
    {
        // Эффект моргания
        yield return StartCoroutine(BlinkEffect());

        // Подъем головы и легкое поднятие камеры
        yield return StartCoroutine(RaiseHeadAndLift());
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

    IEnumerator RaiseHeadAndLift()
    {
        float timeElapsed = 0;
        while (timeElapsed < headRaiseDuration)
        {
            // Интерполируем ротацию камеры
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, timeElapsed / headRaiseDuration);

            // Интерполируем позицию камеры по оси Y
            transform.position = Vector3.Lerp(startPosition, endPosition, timeElapsed / headRaiseDuration);

            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Обеспечиваем точную установку конечного положения
        transform.rotation = endRotation;
        transform.position = endPosition;
    }
}
