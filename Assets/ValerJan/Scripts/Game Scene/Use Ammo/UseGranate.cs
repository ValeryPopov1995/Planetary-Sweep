using UnityEngine;

public class UseGranate : UseAmmo
{
    [SerializeField] GameObject _granatePrefab;
    [SerializeField] Transform _startPosition;

    protected override void Use()
    {
        EventHolder.Singleton.UseGranate?.Invoke();
        ObjectPool.Singleton.InstantiateFromPool(_granatePrefab, _startPosition.position, _startPosition.rotation);
    }
}
