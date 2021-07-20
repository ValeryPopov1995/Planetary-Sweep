using UnityEngine;

public abstract class PoolableObject : MonoBehaviour
{
	protected void Destroy()
	{
		ObjectPool.Singleton.AddPoolableObject(gameObject);
		gameObject.SetActive(false);
	}
}
