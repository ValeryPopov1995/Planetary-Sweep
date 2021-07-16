using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// поворачивается в сторону игрока, учитывая ось по направлению к планете (стоит вертикально к планете)
/// стреляет пуялми из бассейна
public class EnemyTrooper : EnemyBaheviour
{

    protected override void rotateToTarget()
    {
        Vector3 toTarget = (_target.position - _body.position).normalized;
        //Body.rotation = Quaternion.LookRotation(toTarget);
        var look = Quaternion.LookRotation(toTarget, _body.up);
        _body.rotation = new Quaternion(_body.rotation.x, look.y, _body.rotation.z, look.w);
    }

    protected override void attack()
    {
        if (Time.time < _lastAttackTime + Sets.AttackCullback) return;

        _lastAttackTime = Time.time;
        _bulletSpownPoint.LookAt(_target);
        ObjectPool.Singleton.InstantiateFromPool(Sets.Bullet, _bulletSpownPoint.position, _bulletSpownPoint.rotation);
        //Debug.Log("trooper attack");
    }
}
