using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public Transform SpownPoint;
    [SerializeField] PurchaseConfig AutorifleCulldown;

    Transform _camera;
    Settings _settings;
    float _lastFireTime;

    void Start()
    {
        _camera = Camera.main.transform;
        _settings = Settings.Singleton;
    }

    void FixedUpdate()
    {
        var list = Physics.OverlapSphere(_camera.position, _settings.GameBalance.AutoFireRange, LayerMask.GetMask("Enemy"));

        foreach(var e in list)
        {
            float aimAngle = Vector3.Angle(_camera.forward, e.transform.position - _camera.position); // cam.forward
            if (aimAngle <= _settings.GameBalance.AutoFireAngle && Time.time > AutorifleCulldown.Value + _lastFireTime) fire();
        }
    }

    void fire()
    {
        _lastFireTime = Time.time;
        ObjectPool.Singleton.InstantiateFromPool(_settings.GameBalance.AutoriflePrefab, SpownPoint.position, SpownPoint.rotation);
    }
}
