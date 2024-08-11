using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Slider sensitivityXSlider;
    public Slider sensitivityYSlider;
    public Button saveButton;
    public Text sensitivityXText;
    public Text sensitivityYText;

    void Start()
    {
        
        sensitivityXSlider.value = ConfigManager.Config.sensitivityX;
        sensitivityYSlider.value = ConfigManager.Config.sensitivityY;
        UpdateTextFields();

        
        sensitivityXSlider.onValueChanged.AddListener(OnSensitivityXChanged);
        sensitivityYSlider.onValueChanged.AddListener(OnSensitivityYChanged);

        saveButton.onClick.AddListener(OnSaveButtonClicked);
    }

    
    public void OnSensitivityXChanged(float value)
    {
        ConfigManager.Config.sensitivityX = value;
        UpdateTextFields();
    }

    public void OnSensitivityYChanged(float value)
    {
        ConfigManager.Config.sensitivityY = value;
        UpdateTextFields();
    }

    public void OnSaveButtonClicked()
    {
        ConfigManager.SaveConfig();
    }
    private void UpdateTextFields()
    {
        sensitivityXText.text = $"SensX: {ConfigManager.Config.sensitivityX:F1}";
        sensitivityYText.text = $"SensY: {ConfigManager.Config.sensitivityY:F1}";
    }
}
