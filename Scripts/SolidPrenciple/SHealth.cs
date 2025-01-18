using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SHealth : NetworkBehaviour, IDamageable
{
    public int healthPoints = 100;

    public void TakeDamage(int amount)
    {
        healthPoints -= amount;
        if (healthPoints < 0)
        {
            healthPoints = 0;
        }
        Debug.Log($"{gameObject.name} has {healthPoints} health left.");

        if(healthPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} died.");
        //gameObject.SetActive(false); 
        NetworkObject networkObject = gameObject.GetComponent<NetworkObject>();
        NetworkObjectPool.Instance.DeactivateObject(networkObject);
        GameCoin.playerMoney += 20;
    }
}
