using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using System.Collections.Generic;

public class ObjectActivator : NetworkBehaviour
{    
    
    #region old
  
    [SerializeField]
    private GameObject prefab1; // Prefab 1
    [SerializeField]
    private GameObject prefab2; // Prefab 2
    [SerializeField]
    private int poolSizePerPrefab = 10; // Her prefab için havuz boyutu

    private Queue<NetworkObject> prefab1Objects = new Queue<NetworkObject>();
    private Queue<NetworkObject> prefab2Objects = new Queue<NetworkObject>();

    private void Start()
    {
        // Prefableri havuza kaydet
        NetworkObjectPool.Instance.RegisterPrefab(prefab1, poolSizePerPrefab);
        NetworkObjectPool.Instance.RegisterPrefab(prefab2, poolSizePerPrefab);

        // Havuzdan nesneleri alın ama aktif hale getirmeyin
        for (int i = 0; i < poolSizePerPrefab; i++)
        {
            prefab1Objects.Enqueue(NetworkObjectPool.Instance.GetInactiveFromPool(prefab1));
            prefab2Objects.Enqueue(NetworkObjectPool.Instance.GetInactiveFromPool(prefab2));
        }
    }

    public void ActivatePrefab1Object()
    {
        if (prefab1Objects.Count > 0)
        {
            var obj = prefab1Objects.Dequeue();
            NetworkObjectPool.Instance.ActivateObject(obj);
        }
        else
        {
            Debug.LogWarning("Prefab1 için daha fazla nesne yok!");
        }
    }

    public void ActivatePrefab2Object()
    {
        if (prefab2Objects.Count > 0)
        {
            var obj = prefab2Objects.Dequeue();
            NetworkObjectPool.Instance.ActivateObject(obj);
            GameCoin.playerMoney -= 20;
        }
        else
        {
            Debug.LogWarning("Prefab2 için daha fazla nesne yok!");
        }
    }
  
    #endregion
}
