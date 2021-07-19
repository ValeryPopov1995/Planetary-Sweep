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
        //Debug.Log("bullet enabled"); // enabled before instantiated !
        StartCoroutine(initRandom());
        StartCoroutine(checkDestroy());
    }

    void OnDisable() => StopAllCoroutines();

    IEnumerator initRandom()
    {
        float[] angles = new float[3];
        for (int i = 0; i < 3; i++)
        {
            angles[i] = Random.Range(-Sets.AccurecyAngle, Sets.AccurecyAngle);
            //Debug.Log(angles[i]);
        }

        yield return new WaitForEndOfFrame();
        transform.Rotate(angles[0], angles[1], angles[2]);

        var rb = GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;
        //rb.AddForce(Sets.Speed * transform.forward, ForceMode.Impulse);
        //Debug.Log("bullet rotated");
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
            if (collision.gameObject.CompareTag("Player"))
                EventHolder.Singleton.PlayerChangeHealth?.Invoke(-Sets.Damage);
            else if (collision.gameObject.CompareTag("Planetary Object"))
                EventHolder.Singleton.PlanetChangeHealth?.Invoke(-Sets.Damage);
        }
        else
        {
            if (collision.gameObject.CompareTag("Enemy")) collision.gameObject.GetComponentInChildren<EnemyBaheviour>().TakeDamage(this);
        }

        if (_impactPrefab != null) Instantiate(_impactPrefab, transform.position, transform.rotation);
        if (!collision.gameObject.CompareTag("Bullet")) Destroy();
    }

}
