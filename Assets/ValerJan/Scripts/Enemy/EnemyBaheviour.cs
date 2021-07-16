using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaheviour : MonoBehaviour
{
    public enum TargetPriority {player, building}

    public EnemyConfig Sets;
    [SerializeField] Rigidbody _rigid;
    [SerializeField] GravityBody _gravityBody;
    [SerializeField] protected Transform _bulletSpownPoint;

    protected Transform _body;
    protected float _health, _lastAttackTime;
    protected Transform _target;

    protected void Start()
    {
        _body = _rigid.transform;
        _health = Sets.Health;
        tag = "Enemy";

        EventHolder.Singleton.ChangeEnemyCount?.Invoke(1);

        if (Sets.Priority == TargetPriority.player) _target = GameObject.FindWithTag("Player").transform;
        else FindBuilding();
    }

    void FixedUpdate() // logic
    {
        _gravityBody.RotateToPlanet();
        Vector3 moveVector = Vector3.zero;
        if (_target != null)
        {
            rotateToTarget();
            float dis = Vector3.Distance(_body.position, _target.position);
            if (dis < Sets.AttackRange)
                attack();
            else moveVector = _body.forward * Sets.Speed;
        }
        else FindBuilding();

        moveVector -= _body.up * Settings.Singleton.GameBalance.Gravity;
        moveVector *= Time.fixedDeltaTime;

        _rigid.velocity = moveVector;
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
    public void TakeDamage(float damage)
    {
        if (Sets.Blood != null) Instantiate(Sets.Blood, transform.position, transform.rotation);
        _health -= damage;
        if (_health <= 0) death();
    }

    protected abstract void rotateToTarget();
    protected abstract void attack();

    void death()
    {
        EventHolder.Singleton.AwardForKill?.Invoke(Sets.Award);
        EventHolder.Singleton.ChangeEnemyCount?.Invoke(-1);
        Destroy(_body.gameObject);
    }
}
