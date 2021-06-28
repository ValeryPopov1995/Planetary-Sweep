using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public Transform SpownPoint;

    Transform cam;
    PlayerConfig sets;
    float lastTimeFire;

    void Start()
    {
        cam = Camera.main.transform;
        sets = Settings.Singleton.PlayerSets;
    }

    void FixedUpdate()
    {
        var list = Physics.OverlapSphere(cam.position, sets.AutoFireRange, LayerMask.GetMask("Enemy"));

        foreach(var e in list)
        {
            float aimAngle = Vector3.Angle(cam.forward, e.transform.position - cam.position); // cam.forward
            if (aimAngle <= sets.AutoFireAngle && Time.time > sets.AutoFireCullback + lastTimeFire) fire();
        }
    }

    void fire()
    {
        lastTimeFire = Time.time;
        ObjectPool.Singleton.InstantiateFromPool(sets.RifleBulletPrefab, SpownPoint.position, SpownPoint.rotation);
    }
}
