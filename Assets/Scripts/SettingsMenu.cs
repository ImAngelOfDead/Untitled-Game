using UnityEngine;

public class CanvasToggle : MonoBehaviour
{
    public Canvas gameCanvas;
    private bool isCanvasVisible = false;

    void Start()
    {
        
        gameCanvas.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCanvasVisible = !isCanvasVisible;

            if (isCanvasVisible)
            {
                
                gameCanvas.enabled = true;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else
            {
                
                gameCanvas.enabled = false;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1f;
            }
        }
    }
}
