using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable/Enemy Settingss", order = 1)]
public class EnemyConfig : ScriptableObject
{
    public EnemyBaheviour.TargetPriority Priority;
    public float Health, Damage, Speed, SeeRange, AttackRange, AttackCullback;
    public GameObject Bullet, Blood;
}
