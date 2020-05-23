using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 35f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEnemyEffect;
    [SerializeField] GameObject hitTerrainEffect;
    [SerializeField] GameObject hitSolidEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;

    private bool canShoot = true;

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo() > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRayCast()
    {
        var isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out var hitInfo, range);

        if (isHit)
        {
            CreateHitImpact(hitInfo);
            var target = hitInfo.transform.GetComponent<EnemyHealth>();
            target?.TakeDamage(damage);
        }
    }

    private void CreateHitImpact(RaycastHit hitInfo)
    {
        var instantiatedVFX = Instantiate(hitInfo.transform.CompareTag("Terrain")
            ? hitTerrainEffect
            : hitInfo.transform.CompareTag("Enemy")
                ? hitEnemyEffect
                : hitSolidEffect,
            hitInfo.point,
            Quaternion.LookRotation(hitInfo.normal));
        Destroy(instantiatedVFX, 5f);
    }
}
