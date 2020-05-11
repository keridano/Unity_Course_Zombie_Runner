using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;

    void Start()
    {
        if (GameOverCanvas == null) return;

        GameOverCanvas.enabled = false;    
    }

    public void HandleDeath()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
