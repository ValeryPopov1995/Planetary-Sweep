using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float Speed1, Speed2;
    Quaternion _startRotation;
    int _addAngle;

    void Start()
    {
        _startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        _addAngle++;

        Quaternion q1 = Quaternion.AngleAxis(_addAngle * Speed1, Vector3.up);
        Quaternion q2 = Quaternion.AngleAxis(_addAngle * Speed2, Vector3.right);
        transform.rotation = _startRotation * q1 * q2;
    }
}
