using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class MovementController : NetworkBehaviour
{
    public void moveTowards(Transform origin, Transform target, float speed)
    {
        if(!IsOwner) return;
        origin.position = Vector3.MoveTowards(origin.position, target.position, speed * Time.deltaTime);
    }
}
