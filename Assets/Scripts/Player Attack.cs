using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private bool isAttacking;

    [SerializeField] private float damageAfterTime = 0.2f;
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private int damage = 3;

    [SerializeField] private AttackArea attackArea;


    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnAttack(InputValue value)
    {
        if (isAttacking) return;
        anim.SetTrigger("slash");
        StartCoroutine(Hit());
        Debug.Log("Attack!");
    }

    private IEnumerator Hit()
    {
        isAttacking = true;
        yield return new WaitForSeconds(damageAfterTime);

        List<IDamageable> targets = new List<IDamageable>(attackArea.damageablesInRange);

        foreach (IDamageable target in targets)
        {
            if (target != null)
            {
                target.Damage(damage);
                Debug.Log($"Hit {target} for {damage} damage!");
            }
        }

        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;

    }
}
