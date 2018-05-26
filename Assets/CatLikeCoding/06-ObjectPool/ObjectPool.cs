using UnityEngine;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
    public PooledObject _prefeb;
    List<PooledObject> _avaliableObjects = new List<PooledObject>();


    public PooledObject GetObject()
    {
        PooledObject obj;
        int lastAvaliableIndex = _avaliableObjects.Count - 1;
        if (lastAvaliableIndex >= 0)
        {
            obj = _avaliableObjects[lastAvaliableIndex];
            _avaliableObjects.RemoveAt(lastAvaliableIndex);
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate<PooledObject>(_prefeb);
            obj.transform.SetParent(transform, false);
            obj.Pool = this;
        }

        return obj;
    }

    public void AddObject(PooledObject obj)
    {
		obj.gameObject.SetActive(false);
		_avaliableObjects.Add(obj);
    }

    public static ObjectPool GetPool(PooledObject prefab)
    {
        GameObject obj;
        ObjectPool pool;

        if (Application.isEditor)
        {
            obj = GameObject.Find(prefab.name + " Pool");
            if (obj)
            {
                pool = obj.GetComponent<ObjectPool>();
                return pool;
            }
        }

        obj = new GameObject(prefab.name + " Pool");
		DontDestroyOnLoad(obj);
        pool = obj.AddComponent<ObjectPool>();
        pool._prefeb = prefab;
        return pool;
    }

}
