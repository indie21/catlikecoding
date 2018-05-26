using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool Pool { get; set; }

	[System.NonSerialized]
	ObjectPool _poolInstanceForPrefab;

    public void ReturnToPool()
    {
        if (Pool)
        {
            Pool.AddObject(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public T GetPooledInstance<T>() where T: PooledObject
    {
		if (!_poolInstanceForPrefab) {
			_poolInstanceForPrefab = ObjectPool.GetPool(this);
		}
		return (T)_poolInstanceForPrefab.GetObject();
	}

}
