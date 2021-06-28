using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Settings", menuName = "Scriptable/Player Settingss", order = 1)]
public class PlayerConfig : ScriptableObject
{
    public float Speed, Health, Sensetivity, JetpackForce, JetpackCullback, AutoFireAngle, AutoFireRange, AutoFireCullback;
    public GameObject RifleBulletPrefab;
}
