using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using Unity.Netcode;

public class NetworkObjectPool : NetworkBehaviour
{

    #region old
   
    public static NetworkObjectPool Instance { get; private set; }

    private Dictionary<GameObject, ObjectPool<NetworkObject>> objectPools = new Dictionary<GameObject, ObjectPool<NetworkObject>>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterPrefab(GameObject prefab, int prewarmCount)
    {
        if (objectPools.ContainsKey(prefab))
        {
            Debug.LogWarning($"Prefab {prefab.name} is already registered!");
            return;
        }

        ObjectPool<NetworkObject> pool = new ObjectPool<NetworkObject>(
            createFunc: () => Instantiate(prefab).GetComponent<NetworkObject>(),
            actionOnGet: obj => obj.gameObject.SetActive(false), // Başlangıçta pasif
            actionOnRelease: obj => obj.gameObject.SetActive(false),
            actionOnDestroy: obj => Destroy(obj.gameObject),
            defaultCapacity: prewarmCount
        );

        objectPools[prefab] = pool;

        // Havuzu prewarm et
        for (int i = 0; i < prewarmCount; i++)
        {
            pool.Release(pool.Get());
        }
    }

    public NetworkObject GetInactiveFromPool(GameObject prefab)
    {
        if (!objectPools.ContainsKey(prefab))
        {
            Debug.LogError($"Prefab {prefab.name} not registered in pool!");
            return null;
        }

        var obj = objectPools[prefab].Get();
        obj.gameObject.SetActive(false); // Başlangıçta pasif
        return obj;
    }

    public void ActivateObject(NetworkObject obj)
    {
        if (obj != null)
        {
            obj.gameObject.SetActive(true); // Nesneyi aktif hale getir
            obj.Spawn(true); // Ağda nesneyi başlat
        }
    }
    public void DeactivateObject(NetworkObject obj)
    {
        if (obj != null)
        {
            obj.gameObject.SetActive(false); // Nesneyi aktif hale getir
            //NetworkObjectPool.Instance.Release(obj);
            //obj.Spawn(true); // Ağda nesneyi başlat
        }
    }
    
    #endregion
}
