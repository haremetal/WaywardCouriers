using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private Animator anim;
    private bool isAttacking;

    [SerializeField] private float damageAfterTime;

    [SerializeField] private int damage;

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

        foreach (var attackAreaDamageable in attackArea.damageablesInRange)
        {
            yield return new WaitForSeconds(damageAfterTime);
            attackAreaDamageable.Damage(damage);
        }

        yield return new WaitForSeconds(damageAfterTime);
        isAttacking = false;

    }
}
