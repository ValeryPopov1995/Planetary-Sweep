using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    public float Speed1, Speed2;
    Quaternion startRotation;
    int Angle;

    void Start()
    {
        startRotation = transform.rotation;
    }

    void FixedUpdate()
    {
        Angle++;

        Quaternion q1 = Quaternion.AngleAxis(Angle * Speed1, Vector3.up);
        Quaternion q2 = Quaternion.AngleAxis(Angle * Speed2, Vector3.right);
        transform.rotation = startRotation * q1 * q2;
    }
}
