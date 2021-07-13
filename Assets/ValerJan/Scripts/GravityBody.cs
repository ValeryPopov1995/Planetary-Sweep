using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravityBody : MonoBehaviour
{
    Planet _planet;

    void Start()
    {
        var rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    void FixedUpdate()
    {
        Vector3 targetDir = (transform.position - Vector3.zero).normalized;
        transform.rotation = Quaternion.FromToRotation(transform.up, targetDir) * transform.rotation;
    }
}
