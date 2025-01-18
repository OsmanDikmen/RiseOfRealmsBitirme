using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class Spawner : NetworkBehaviour
{

    #region old code
    public GameObject prefab1;
    public GameObject prefab2;

    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public int poolSize = 10;

    private void Start()
    {
        // Havuzları oluştur
        PoolManager.Instance.CreatePool(prefab1, poolSize, "Prefab1Pool");
        PoolManager.Instance.CreatePool(prefab2, poolSize, "Prefab2Pool");
    }

    public void SpawnPrefab1()
    {
        PoolManager.Instance.SpawnFromPool("Prefab1Pool", spawnPoint1.position, Quaternion.identity);
    }

    public void SpawnPrefab2()
    {
        PoolManager.Instance.SpawnFromPool("Prefab2Pool", spawnPoint2.position, Quaternion.identity);
        
    }
   
    #endregion 
}
