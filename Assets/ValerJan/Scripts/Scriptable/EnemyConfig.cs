using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable/Enemy Settingss", order = 1)]
public class EnemyConfig : ScriptableObject
{
    [ReadOnly] public EnemyBaheviour.TargetPriority Priority;
    [ReadOnly] public float Health, Damage, Speed, SeeRange, AttackRange, AttackCullback;
    [ReadOnly] public int Award = 1;
    [ReadOnly] public GameObject Bullet, Blood;
}
