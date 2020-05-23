using System;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;

    void Start()
    {
        if (currentWeapon > transform.childCount - 1)
            currentWeapon = 0;
        SetWeaponActive();
    }

    void Update()
    {
        int previousWeapon = currentWeapon;

        ProcessKeyInput();
        ProcessScroolWheel();

        if (previousWeapon != currentWeapon)
            SetWeaponActive();
    }

    private void ProcessScroolWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else
                currentWeapon++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (currentWeapon <= 0)
                currentWeapon = transform.childCount - 1;
            else
                currentWeapon--;
        }

    }

    private void ProcessKeyInput()
    {
        currentWeapon = Input.GetKeyDown(KeyCode.Alpha1)
            ? 0
            : Input.GetKeyDown(KeyCode.Alpha2)
                ? 1
                : Input.GetKeyDown(KeyCode.Alpha3)
                    ? 2
                    : currentWeapon;
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(weaponIndex == currentWeapon);
            weaponIndex++;
        }
    }

}
