using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Enemy : NetworkBehaviour , ITarget
{
    public Transform GetTransform() => transform;
    public bool IsValidTarget() =>  true;
}
