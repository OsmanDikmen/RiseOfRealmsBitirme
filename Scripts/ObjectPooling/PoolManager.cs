using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PoolManager : NetworkBehaviour
{
    public static PoolManager Instance;

    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            poolDictionary = new Dictionary<string, Queue<GameObject>>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CreatePool(GameObject prefab, int poolSize, string poolKey)
    {
        if (!poolDictionary.ContainsKey(poolKey))
        {
            poolDictionary[poolKey] = new Queue<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(prefab);
                obj.SetActive(false); // Nesneyi pasif yap
                poolDictionary[poolKey].Enqueue(obj);
            }
        }
    }

    public GameObject SpawnFromPool(string poolKey, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolKey) || poolDictionary[poolKey].Count == 0)
        {
            Debug.LogWarning($"Pool with key {poolKey} doesn't exist or is empty!");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[poolKey].Dequeue();
        objectToSpawn.SetActive(true); // Nesneyi aktif yap
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[poolKey].Enqueue(objectToSpawn);
        return objectToSpawn;
    }
}