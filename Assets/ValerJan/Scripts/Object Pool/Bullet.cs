using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : PoolableObject
{
    public BulletConfig Sets;
    [SerializeField] GameObject _impactPrefab;
    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rigidbody.MovePosition(transform.position + transform.forward * Sets.Speed * Time.deltaTime);
    }

    void OnEnable()
    {
        //Debug.Log("bullet enabled"); // enabled before instantiated from pool !
        StartCoroutine(initRandom());
        StartCoroutine(checkDestroy());
    }

    void OnDisable() => StopAllCoroutines();

    IEnumerator initRandom()
    {
        float[] angles = new float[3];
        for (int i = 0; i < 3; i++)
            angles[i] = Random.Range(-Sets.AccurecyAngle, Sets.AccurecyAngle);

        yield return new WaitForEndOfFrame();
        transform.Rotate(angles[0], angles[1], angles[2]);

        var rb = GetComponent<Rigidbody>();
    }

    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(Sets.TimerToDestroy);
        Destroy();
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject target = collision.gameObject;
        var holder = EventHolder.Singleton;
        if (Sets.EnemyBullet)
        {
            if (target.CompareTag("Player"))
                holder.PlayerChangeHealth?.Invoke(-Sets.Damage);
            else if (target.CompareTag("Planetary Object"))
                holder.PlanetChangeHealth?.Invoke(-Sets.Damage);
        }
        else
        {
            if (target.CompareTag("Enemy")) target.GetComponentInChildren<EnemyBaheviour>().TakeDamage(this);
        }

        if (_impactPrefab != null) Instantiate(_impactPrefab, transform.position, transform.rotation);
        if (!target.CompareTag("Bullet")) Destroy();
    }

}
