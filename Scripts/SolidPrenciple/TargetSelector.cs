using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TargetSelector : NetworkBehaviour
{
    public Transform FindNearestTarget(Transform origin, float detectionRadious, string targetTag)
    {
        Collider[] hits = Physics.OverlapSphere(origin.position, detectionRadious);

        Transform nearestTarget = null;
        float closestDistance = Mathf.Infinity;

        foreach(Collider hit in hits)
        {
            if(hit.CompareTag(targetTag))
            {
                float distance = Vector3.Distance(origin.position, hit.transform.position);
                if(distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestTarget = hit.transform;
                }
            }
        }
        return nearestTarget;
    }
}
