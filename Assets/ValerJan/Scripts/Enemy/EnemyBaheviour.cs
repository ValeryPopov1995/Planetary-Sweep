using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaheviour : MonoBehaviour
{
    public enum TargetPriority {player, building}

    public EnemyConfig Sets;
    public Transform Body, BulletSpownPoint;

    Rigidbody _rigidbody;
    protected float _health, _lastAttackTime;
    protected Transform _target;

    protected void Start()
    {
        _rigidbody = Body.GetComponent<Rigidbody>();
        _health = Sets.Health;
        tag = "Enemy";

        EventHolder.Singleton.AddEnemyCount?.Invoke(1);

        if (Sets.Priority == TargetPriority.player) _target = GameObject.FindWithTag("Player").transform;
        else FindBuilding();
    }

    void FixedUpdate() // logic
    {
        if (_target != null)
        {
            rotateToTarget();
            float dis = Vector3.Distance(Body.position, _target.position);
            if (dis < Sets.AttackRange)
            {
                attack();
                _rigidbody.velocity = Vector3.zero;
            }
            else _rigidbody.velocity = Body.forward * Sets.Speed;
        }
        else FindBuilding();

        _rigidbody.velocity -= Body.up * Settings.Singleton.GameBalance.Gravity;
        _rigidbody.velocity *= Time.fixedDeltaTime;
    }

    public void SetTarget(Transform target) // for enemy scanner
    {
        this._target = target;
    }

    public void FindBuilding() // for enemy scanner
    {
        _target = GameObject.FindWithTag("Planetary Object").transform;
    }

    public void TakeDamage(Bullet bullet)
    {
        if (Sets.Blood != null) Instantiate(Sets.Blood, bullet.transform.position, bullet.transform.rotation);
        _health -= bullet.Sets.Damage;
        if (_health <= 0) death();
    }

    protected abstract void rotateToTarget();
    protected abstract void attack();

    void death()
    {
        EventHolder.Singleton.AddEnemyCount?.Invoke(-1);
        Destroy(Body.gameObject);
    }
}
