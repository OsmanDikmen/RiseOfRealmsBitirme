using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class SAttackToEnemies : NetworkBehaviour
{
    public float detectionRadius = 10f;
    public float attackRange = 2f;
    public float moveSpeed = 3f;
    public Transform targetTower;
    public float attackCooldown = 1f;
    public string myTargetTag;
    public string myTowerTag;

    private TargetSelector targetSelector;
    private MovementController movementController;
    private AttackController attackController;
    private Transform currentTarget;
    private float lastAttackTime;

    private void Awake()
    {
        targetSelector = GetComponent<TargetSelector>();
        movementController = GetComponent<MovementController>();
        attackController = GetComponent<AttackController>();

        if (targetTower == null)
        {
            targetTower = GameObject.FindWithTag(myTowerTag).transform; // Tag'i 'Tower' olan nesneyi bulur.
        }
    }

    private void Update()
    {
        FindAndSetTarget();

        if (currentTarget != null)
        {
            //if(!IsOwner) return;
            MoveAndAttack();
        }
    }

    private void FindAndSetTarget()
    {
        Transform nearestEnemy = targetSelector.FindNearestTarget(transform, detectionRadius, myTargetTag);
        currentTarget = nearestEnemy != null ? nearestEnemy : targetTower;
    }

    private void MoveAndAttack()
    {
        
        if (Vector3.Distance(transform.position, currentTarget.position) > attackRange)
        {
            movementController.moveTowards(transform, currentTarget, moveSpeed);
        }
        else
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                ITarget targetComponent = currentTarget.GetComponent<ITarget>();
                if (targetComponent != null)
                {
                    attackController.Attack(targetComponent);
                    lastAttackTime = Time.time; 
                }
            }
        }
    }
}
