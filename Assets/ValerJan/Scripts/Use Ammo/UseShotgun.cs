using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseShotgun : UseAmmo
{
    [SerializeField] Transform _spownPoint;
    [SerializeField] Animator _animator;
    [SerializeField] AudioSource _source;
    [SerializeField] int _bulletCount;
    [SerializeField] float _delay;

    protected override void Use()
    {
        if (_source != null)
        {
            if (_source.isPlaying) _source.Stop();
            _source.Play();
        }
        
        EventHolder.Singleton.UseShotgun?.Invoke();
        _animator.SetTrigger("shoot");
        StartCoroutine(spown());
    }

    IEnumerator spown()
    {
        yield return new WaitForSeconds(_delay);

        for (int i = 0; i < _bulletCount; i++)
        {
            //yield return new WaitForEndOfFrame();
            ObjectPool.Singleton.InstantiateFromPool(Settings.Singleton.Prefabs.ShotgunPrefab, _spownPoint.position, _spownPoint.rotation);
            //Debug.Log("shotgun bullet instantiated");
        }
    }
}
