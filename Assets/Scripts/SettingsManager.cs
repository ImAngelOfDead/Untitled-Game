using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider sensitivityXSlider;
    public Slider sensitivityYSlider;
    public Button saveButton;

    void Start()
    {
        // Загружаем текущие настройки из конфигурационного файла и устанавливаем значения UI-элементов
        sensitivityXSlider.value = ConfigManager.Config.sensitivityX;
        sensitivityYSlider.value = ConfigManager.Config.sensitivityY;


        // Привязка событий UI-элементов к функциям
        sensitivityXSlider.onValueChanged.AddListener(OnSensitivityXChanged);
        sensitivityYSlider.onValueChanged.AddListener(OnSensitivityYChanged);

        saveButton.onClick.AddListener(OnSaveButtonClicked);
    }

    // Функции-обработчики для изменений настроек
    public void OnSensitivityXChanged(float value)
    {
        ConfigManager.Config.sensitivityX = value;
    }

    public void OnSensitivityYChanged(float value)
    {
        ConfigManager.Config.sensitivityY = value;
    }

    // Функция для сохранения настроек при нажатии кнопки Save
    public void OnSaveButtonClicked()
    {
        ConfigManager.SaveConfig();
    }
}
