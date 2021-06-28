using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaheviour : MonoBehaviour
{
    public enum TargetPriority {player, building}

    public EnemyConfig Sets;
    public Transform Body, BulletSpownPoint;

    Rigidbody rb;
    protected float health, lastAttack;
    protected Transform target;

    protected void Start()
    {
        rb = Body.GetComponent<Rigidbody>();
        health = Sets.Health;
        tag = "Enemy";

        EventHolder.Singlton.AddEnemyCount?.Invoke(1);

        if (Sets.Priority == TargetPriority.player) target = GameObject.FindWithTag("Player").transform;
        else FindBuilding();
    }

    void FixedUpdate() // logic
    {
        if (target != null)
        {
            rotateToTarget();
            float dis = Vector3.Distance(Body.position, target.position);
            if (dis < Sets.AttackRange)
            {
                attack();
                rb.velocity = Vector3.zero;
            }
            else rb.velocity = Body.forward * Sets.Speed;
        }
        else FindBuilding();

        // vertical speed - gravity
        rb.velocity -= Body.up * Settings.Singleton.GamePlaySets.Gravity;
        rb.velocity *= Time.fixedDeltaTime;
    }

    public void SetTarget(Transform target) // for enemy scanner
    {
        this.target = target;
    }

    public void FindBuilding() // for enemy scanner
    {
        target = GameObject.FindWithTag("Planetary Object").transform;
    }

    public void TakeDamage(Bullet bullet)
    {
        if (Sets.Blood != null) Instantiate(Sets.Blood, bullet.transform.position, bullet.transform.rotation);
        health -= bullet.Sets.Damage;
        if (health <= 0) death();
    }

    protected abstract void rotateToTarget();
    protected abstract void attack();

    void death()
    {
        EventHolder.Singlton.AddEnemyCount?.Invoke(-1);
        Destroy(Body.gameObject);
    }
}
