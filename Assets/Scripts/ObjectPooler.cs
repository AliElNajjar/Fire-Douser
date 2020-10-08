using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject objectToPool;
        public int amountToPool;
    }

    public List<GameObject> pooledObjects;
    public List<ObjectPoolItem> itemsToPool;


    public static ObjectPooler SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        //Put all objects in pool but inactive
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject prefab = Instantiate(item.objectToPool);
                prefab.SetActive(false);
                pooledObjects.Add(prefab);
            }
        }
    }

    public GameObject GetPooledObject(string people)
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == people)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
