using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead;

    public bool IsDead()
    {
        return isDead;
    }

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
        if (isDead) return;

        isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }
}
