using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class AttackController : NetworkBehaviour
{
    public int damage = 10;

    public void Attack(ITarget target)
    {
        if (target != null && target.IsValidTarget())
        {
            IDamageable damageable = target.GetTransform().GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(damage);
                Debug.Log($"Attacked {target.GetTransform().name} for {damage} damage.");
            }
        }
    }
}

