using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : PoolableObject
{
    public BulletConfig Sets;
    [SerializeField] GameObject _impactPrefab;
    Rigidbody _rigidbody;
    Vector3 _forward;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _rigidbody.MovePosition(transform.position + _forward * Sets.Speed * Time.deltaTime);
    }

    void OnEnable()
    {
        transform.Rotate(
            Random.Range(0, Sets.AccurecyAngle),
            Random.Range(0, Sets.AccurecyAngle),
            Random.Range(0, Sets.AccurecyAngle));
        _forward = transform.forward;

        StartCoroutine(checkDestroy());
    }

    void OnDisable() => StopAllCoroutines();

    IEnumerator checkDestroy()
    {
        yield return new WaitForSeconds(Sets.TimerToDestroy);
        Destroy();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.isTrigger) return; // it is very important small detail, syka
        GameObject target = other.gameObject;
        Debug.Log(gameObject.name + " triggered with " + target.name);

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
            if (target.CompareTag("Enemy")) target.GetComponentInChildren<AIHealth>().TakeDamage(Sets.Damage);
        }

        if (_impactPrefab != null) Instantiate(_impactPrefab, transform.position, transform.rotation);
        if (!target.CompareTag("Bullet")) Destroy();
    }
}
