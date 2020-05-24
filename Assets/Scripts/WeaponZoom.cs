using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] RigidbodyFirstPersonController fpsController;

    private const float zoomedInMouseSensitivity = 0.5f;
    private const float zoomedInFieldOfView = 20f;

    float baseFieldOfView;
    float baseMouseXSensitivity;
    float baseMouseYSensitivity;

    bool isZoomedIn;

    private void OnDisable()
    {
        if (isZoomedIn)
            ZoomOut();
    }

    void Start()
    {
        baseFieldOfView = Camera.main.fieldOfView;
        baseMouseXSensitivity = fpsController.mouseLook.XSensitivity;
        baseMouseYSensitivity = fpsController.mouseLook.YSensitivity;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            if (isZoomedIn)
                ZoomOut();
            else
                ZoomIn();
        }
    }

    private void ZoomIn()
    {
        isZoomedIn = true;
        Camera.main.fieldOfView = zoomedInFieldOfView;
        fpsController.mouseLook.XSensitivity = zoomedInMouseSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInMouseSensitivity;
    }

    private void ZoomOut()
    {
        isZoomedIn = false;
        Camera.main.fieldOfView = baseFieldOfView;
        fpsController.mouseLook.XSensitivity = baseMouseXSensitivity;
        fpsController.mouseLook.YSensitivity = baseMouseYSensitivity;
    }

}
