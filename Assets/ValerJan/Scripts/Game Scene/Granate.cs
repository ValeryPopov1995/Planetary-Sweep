using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Granate : MonoBehaviour
{
    [SerializeField] int _Impulse, _timer, _randomTorque;
    [SerializeField] GameObject _explosionPrefab;
    Rigidbody _rigid;

    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _rigid.AddForce(transform.forward * _Impulse, ForceMode.Impulse);
        _rigid.AddTorque(Random.insideUnitSphere * _randomTorque, ForceMode.Impulse);
        Invoke("explose", _timer);
    }

    void FixedUpdate()
    {
        Vector3 gravity = (Vector3.zero - transform.position).normalized;
        _rigid.AddForce(gravity * Physics.gravity.magnitude, ForceMode.Force);
    }

    void explose()
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
