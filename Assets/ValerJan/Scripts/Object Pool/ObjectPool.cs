using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour
{
	public static ObjectPool Singleton;
	
	List<GameObject> _pool = new List<GameObject>();
	
	void Start()
	{
		if (Singleton == null) Singleton = this;
		else Destroy(this);
	}
	
	public void InstantiateFromPool(GameObject poolablePrefab, Vector3 position, Quaternion rotation)
	{
		if (!poolablePrefab.TryGetComponent<PoolableObject>(out var ob)) Debug.LogError("instantiating object by ObjectPool is not poolable object");
		bool founded = false;
		foreach (var e in _pool)
		{
			if (e.name == poolablePrefab.name + "(Clone)")
			{
				founded = true;
				
				e.transform.position = position;
				e.transform.rotation = rotation;
				
				e.SetActive(true);
				_pool.Remove(e);
				
				break;
			}
		}
		
		if (!founded)
		{
			var o = Instantiate(poolablePrefab, position, rotation);
            o.transform.parent = transform;
			//Debug.Log("в ObjectPool отсутствует свободный " + prefab + ", создан новый");
		}
	}
	
	public void AddPoolableObject(GameObject poolableObject)
	{
		_pool.Add(poolableObject);
	}
	
	// TODO delete
	public IEnumerator ClearPool()
	{
		foreach( var e in _pool)
		{
			Destroy(e);
			yield return new WaitForEndOfFrame();
		}
		_pool.Clear();
	}
	
	public IEnumerator ClearPool(GameObject prefab)
	{
		foreach (var e in _pool)
		{
			if (e == prefab)
			{
				Destroy(e);
				_pool.Remove(e);
				yield return new WaitForEndOfFrame();
			}
		}
	}
}
