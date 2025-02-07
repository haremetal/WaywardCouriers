using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<IDamageable> damageablesInRange { get;  } = new();

    public void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null )
        {
            damageablesInRange.Add( damageable );
        }
    }

    public void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if( damageable != null && damageablesInRange.Contains(damageable))
        {
            damageablesInRange.Remove( damageable );
        }
    }
}
