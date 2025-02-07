using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void IDamageable.Damage(int amount)
    {
        //anim.SetTrigger("hurt");
        Debug.Log($"Ow. Screw you! I just took {amount}");
    }
}
