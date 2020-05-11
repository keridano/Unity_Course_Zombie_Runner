using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 40f;

    PlayerHealth target;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();            
    }

    public void AttackHitEvent()
    {
        if (target == null) return;

        Debug.Log("Bang bang");
        target.TakeDamage(damage);
    }
}
