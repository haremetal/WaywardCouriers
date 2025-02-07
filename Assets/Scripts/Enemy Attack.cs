using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private Animator anim;
    private bool isAttacking;

    [SerializeField] private float damageAfterTime = 0.5f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private int damage = 2;
    [SerializeField] private AttackArea attackArea;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAttacking)
        {
            Debug.Log($"Damageables in range: {attackArea.damageablesInRange.Count}");
            if (attackArea.damageablesInRange.Count > 0)
            {
                StartCoroutine(Attack());
            }
        }
    }

    private IEnumerator Attack()
    {
        isAttacking = true;

        while (attackArea.damageablesInRange.Count > 0)
        {
            IDamageable target = attackArea.damageablesInRange[0];
            anim.SetTrigger("attack");
            yield return new WaitForSeconds(damageAfterTime);

            if (target != null)
            {
                target.Damage(damage);
                Debug.Log($"Enemy attacked {target} for {damage} damage!");
            }

            yield return new WaitForSeconds(attackCooldown);
        }

        isAttacking = false;
    }
}
