using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
	protected void Destroy()
	{
		ObjectPool.Singleton.AddPoolableObject(gameObject);
		gameObject.SetActive(false);
	}
}
