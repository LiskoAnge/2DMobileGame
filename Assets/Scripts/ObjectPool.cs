using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //this allows me to make instances of this class editable from within the Inspector
public class ObjectPoolItem
{
    public GameObject objectToPool;
    public int amountToPool = 10;
}


public class ObjectPool : MonoBehaviour
{
    public static ObjectPool sharedInstance;   //creating a singleton

    private List<GameObject> pooledObjects = new List<GameObject>();


    public List<ObjectPoolItem> itemsToPool;     // list to hold instances of ObjectPoolItem



    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    /*
    private void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    } */

    void Start()
    {
        pooledObjects = new List<GameObject>();
        foreach (ObjectPoolItem item in itemsToPool)    //foreach loop to run through all instances of ObjectPoolItem
        {                                                         //and add the appropriate objects to the object pool
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)      //taking here a string parameter so that i can request an object by its tag
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)   //thesearch an inactive object that has a matching tag
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                /*
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }*/
            }
        }
        return null;
    }


    /*

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)     //if there is an object NOT active in the hierarchy, hence available, return it
            {
                return pooledObjects[i];
            }
        }
        return null;
    } */
}