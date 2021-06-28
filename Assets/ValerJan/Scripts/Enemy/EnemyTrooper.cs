using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// поворачивается в сторону игрока, учитывая ось по направлению к планете (стоит вертикально к планете)
/// стреляет пуялми из бассейна
public class EnemyTrooper : EnemyBaheviour
{
    protected override void rotateToTarget()
    {
        Vector3 toTarget = (target.position - Body.position).normalized;
        //Body.rotation = Quaternion.LookRotation(toTarget);
        var look = Quaternion.LookRotation(toTarget, Body.up);
        Body.rotation = new Quaternion(Body.rotation.x, look.y, Body.rotation.z, look.w);
    }

    protected override void attack()
    {
        if (Time.time < lastAttack + Sets.AttackCullback) return;

        lastAttack = Time.time;
        ObjectPool.Singleton.InstantiateFromPool(Sets.Bullet, BulletSpownPoint.position, BulletSpownPoint.rotation);
        //Debug.Log("trooper attack");
    }
}
