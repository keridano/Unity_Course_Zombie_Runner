using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDying;

    public void TakeDamage(float damage)
    {
        ProcessHit(damage);
        if (hitPoints <= 0)
            KillPlayer();
    }

    private void ProcessHit(float damage)
    {
        hitPoints -= damage;
    }

    private void KillPlayer()
    {
        if (isDying) return; //prevents multiple particle instances

        isDying = true;
        GetComponent<DeathHandler>().HandleDeath();
    }
}
