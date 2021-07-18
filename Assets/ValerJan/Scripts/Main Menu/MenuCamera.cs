using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [Range(.1f, .9f)]
    [SerializeField] float _lerp = .5f;
    [SerializeField] Transform _target;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.position, _lerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, _target.rotation, _lerp);
    }

    public void SetPosition(Transform transform)
    {
        _target = transform;
    }
}
