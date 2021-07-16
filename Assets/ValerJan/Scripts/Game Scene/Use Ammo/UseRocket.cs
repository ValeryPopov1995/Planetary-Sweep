using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseRocket : UseAmmo
{
    [SerializeField] GameObject _rocketPrefab;
    [SerializeField] Transform _startPosition;

    protected override void Use()
    {
        EventHolder.Singleton.UseRocket?.Invoke();
        ObjectPool.Singleton.InstantiateFromPool(_rocketPrefab, _startPosition.position, _startPosition.rotation);
    }
}
