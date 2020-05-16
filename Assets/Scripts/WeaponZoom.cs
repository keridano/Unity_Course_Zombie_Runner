using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class WeaponZoom : MonoBehaviour
{
    private const float zoomedInMouseSensitivity = 0.5f;
    private const float zoomedInFieldOfView = 20f;

    float baseFieldOfView;
    float baseMouseXSensitivity;
    float baseMouseYSensitivity;

    bool isZoomedIn;

    RigidbodyFirstPersonController fpsController;

    void Start()
    {
        baseFieldOfView = Camera.main.fieldOfView;
        fpsController = GetComponent<RigidbodyFirstPersonController>();
        baseMouseXSensitivity = fpsController.mouseLook.XSensitivity;
        baseMouseYSensitivity = fpsController.mouseLook.YSensitivity;

    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire2"))
        {
            if (isZoomedIn)
            {
                isZoomedIn = false;
                Camera.main.fieldOfView = baseFieldOfView;
                fpsController.mouseLook.XSensitivity = baseMouseXSensitivity;
                fpsController.mouseLook.YSensitivity = baseMouseYSensitivity;
            }
            else
            {
                isZoomedIn = true;
                Camera.main.fieldOfView = zoomedInFieldOfView;
                fpsController.mouseLook.XSensitivity = zoomedInMouseSensitivity;
                fpsController.mouseLook.YSensitivity = zoomedInMouseSensitivity;
            }
        }
    }
}
