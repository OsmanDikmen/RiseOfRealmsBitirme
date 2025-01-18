using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class TestNetworkRpc : NetworkBehaviour
{
    public ObjectActivator Act;

    public void OnMyButtonPressed()
    {
        DebugHeyServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    private void DebugHeyServerRpc()
    {
        Debug.Log("hey");
        Act.ActivatePrefab1Object();
    }
}

