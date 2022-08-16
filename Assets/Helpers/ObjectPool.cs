using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    [SerializeField] public List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;

    void Awake()
    {
        if (SharedInstance != null && SharedInstance != this)
        {
            Destroy(this);
        }
        else
        {
            SharedInstance = this;
        }

        pooledObjects = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            CreateObject();
        }

    }

    private GameObject CreateObject()
    {
        GameObject tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);
        return tmp;
    }

    public GameObject GetPooledObject()
    {
        
        for (int i = 0; i < amountToPool; i++)
        {
            if (pooledObjects[i] == null)
            {
                pooledObjects[i] = CreateObject();
            }

            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }


    public List<GameObject> GetActivePooledObjects()
    {
        var pool = new List<GameObject>();

        for (int i = 0; i < amountToPool; i++)
        {
            if (pooledObjects[i].activeInHierarchy)
            {
                pool.Add(pooledObjects[i]);
            }
        }
        return pool;
    }
}
