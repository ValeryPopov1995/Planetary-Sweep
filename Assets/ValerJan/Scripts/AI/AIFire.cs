using System.Collections;
using UnityEngine;

[AddComponentMenu("AI Enemy/AI Fire")]
public class AIFire : AIScaning
{
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] Transform _spownPoint;
    [Min(.1f)] [SerializeField] float _attackDistance = 6, _fireRate = .1f, _reloadTime = 1.5f;
    [Min(1)] [SerializeField] int _magazineCount = 3;
    [SerializeField] Animator _controller;

    float _lastFireTime;

    void Update()
    {
        if (Scaner.Target == null) return;
        if (_lastFireTime + _reloadTime > Time.time) return;
        float dis = Vector3.Distance(transform.position, Scaner.Target.position);
        if (dis > _attackDistance) return;

        _lastFireTime = Time.time;
        StartCoroutine(fire());
    }

    IEnumerator fire()
    {
        for (int i = 0; i < _magazineCount; i++)
        {
            Vector3 lookDirection = Scaner.Target.position - _spownPoint.position;
            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            ObjectPool.Singleton.InstantiateFromPool(_bulletPrefab, _spownPoint.position, lookRotation);
            if (_controller != null) _controller.SetTrigger("fire");
            yield return new WaitForSeconds(_fireRate);
        }
    }
}
