using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [Range(.9f, .99f)]
    [SerializeField] float _lerp = .9f;
    Vector3 _target;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target, _lerp);
    }

    public void SetPosition(Transform position)
    {
        _target = position.position;
    }
}
