using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable] public class Pool 
    {
        public string Tag;
        public int Size;
        public GameObject Prefab;
    }

    #region Singleton
    public static ObjectPool Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }


    #endregion

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (var pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.Size; i++)
            {
                GameObject obj = Instantiate(pool.Prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.Tag, objectPool);
        }
    }
    public GameObject SpawnerFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($" Pool  with teg {tag } doesent excist");
            return null;
        }

        GameObject objectToSpawn =  poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IObjectPool poolObject = objectToSpawn.GetComponent<IObjectPool>();

        if(poolObject != null)
        {
            poolObject.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
