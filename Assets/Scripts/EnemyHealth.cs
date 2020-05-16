using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDying;

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().OnDamageTaken();
        ProcessHit(damage);
        if (hitPoints <= 0)
            KillEnemy();
    }

    private void ProcessHit(float damage)
    {
        hitPoints -= damage;
    }

    private void KillEnemy()
    {
        if (isDying) return; //prevents multiple particle instances

        isDying = true;
        //var instantiatedFx = Instantiate(deathFx, transform.position, Quaternion.identity);
        //instantiatedFx.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
