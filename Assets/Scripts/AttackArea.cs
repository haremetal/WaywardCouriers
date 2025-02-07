using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public List<IDamageable> damageablesInRange { get;  } = new();

    private readonly List<IDamageable> toAdd = new();
    private readonly List<IDamageable> toRemove = new();

    private void Update()
    {
        if (toAdd.Count > 0)
        {
            foreach (IDamageable damageable in toAdd)
            {
                if (!damageablesInRange.Contains(damageable))
                {
                    damageablesInRange.Add(damageable);
                    Debug.Log($"Added {damageable} to damageablesInRange.");
                }
            }
            toAdd.Clear();
        }

        if (toRemove.Count > 0)
        {
            foreach (IDamageable damageable in toRemove)
            {
                if (damageablesInRange.Contains(damageable))
                {
                    damageablesInRange.Remove(damageable);
                    Debug.Log($"Removed {damageable} from damageablesInRange.");
                }
            }
            toRemove.Clear();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null && !toAdd.Contains(damageable) && !damageablesInRange.Contains(damageable))
        {
            toAdd.Add(damageable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null && !toRemove.Contains(damageable))
        {
            toRemove.Add(damageable);
        }
    }
}
