using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public Transform SpownPoint;

    Transform cam;
    Settings sets;
    float lastTimeFire;

    void Start()
    {
        cam = Camera.main.transform;
        sets = Settings.Singleton;
    }

    void FixedUpdate()
    {
        var list = Physics.OverlapSphere(cam.position, sets.GamePlaySets.AutoFireRange, LayerMask.GetMask("Enemy"));

        foreach(var e in list)
        {
            float aimAngle = Vector3.Angle(cam.forward, e.transform.position - cam.position); // cam.forward
            if (aimAngle <= sets.GamePlaySets.AutoFireAngle && Time.time > sets.Purchases.AutorifleCulldown.CurrentValue + lastTimeFire) fire();
        }
    }

    void fire()
    {
        lastTimeFire = Time.time;
        ObjectPool.Singleton.InstantiateFromPool(sets.GamePlaySets.AutoriflePrefab, SpownPoint.position, SpownPoint.rotation);
    }
}
