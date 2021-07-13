using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : PoolableObject
{
    public BulletConfig Sets;
    [SerializeField] GameObject _impactPrefab;

    void OnEnable()
    {
        var rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.AddForce(Sets.Speed * transform.forward, ForceMode.Impulse);
        StartCoroutine(checkDestroy());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(Sets.TimerToDestroy);
        Destroy();
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("bullet impacted in" + collision.gameObject.name);
        if (Sets.EnemyBullet)
        {
            if (collision.gameObject.CompareTag("Player")) { EventHolder.Singlton.PlayerChangeHealth?.Invoke(Sets.Damage); }
            else if (collision.gameObject.CompareTag("Planetary Object")) { EventHolder.Singlton.PlanetChangeHealth?.Invoke(Sets.Damage); }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy")) collision.gameObject.GetComponentInChildren<EnemyBaheviour>().TakeDamage(this);
        }

        if (_impactPrefab != null) Instantiate(_impactPrefab, transform.position, transform.rotation);
        Destroy();
    }
}
