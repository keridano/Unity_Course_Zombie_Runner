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

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            if(ammoSlot.GetCurrentAmmo() > 0)
            {
                muzzleFlash.Play();
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        var isHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out var hitInfo, range);

        if (isHit)
        {
            CreateHitImpact(hitInfo);
            var target = hitInfo.transform.GetComponent<EnemyHealth>();
            target?.TakeDamage(damage);
        }

        ammoSlot.ReduceCurrentAmmo();
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
