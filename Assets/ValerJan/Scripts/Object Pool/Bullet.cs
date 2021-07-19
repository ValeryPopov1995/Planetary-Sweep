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
        //Debug.Log(gameObject.name + " spowned");
        
        var rb = GetComponent<Rigidbody>();

        var r = transform.rotation;
        r = new Quaternion(
            r.x + Random.Range(0, Sets.AccurecyAngle),
            r.y + Random.Range(0, Sets.AccurecyAngle),
            r.z + Random.Range(0, Sets.AccurecyAngle),
            r.w);

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
            if (collision.gameObject.CompareTag("Player")) { EventHolder.Singleton.PlayerChangeHealth?.Invoke(-Sets.Damage); }
            else if (collision.gameObject.CompareTag("Planetary Object")) { EventHolder.Singleton.PlanetChangeHealth?.Invoke(-Sets.Damage); }
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy")) collision.gameObject.GetComponentInChildren<EnemyBaheviour>().TakeDamage(this);
        }

        if (_impactPrefab != null) Instantiate(_impactPrefab, transform.position, transform.rotation);
        if (!collision.gameObject.CompareTag("Bullet")) Destroy();
    }
}
