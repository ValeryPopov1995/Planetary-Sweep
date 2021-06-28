using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Purchases", menuName = "Scriptable/Purchases", order = 1)]
public class PurchasesConfig : ScriptableObject
{
    public Purchase ShotgunDamage, ShotgunCulldown, ShotgunMaxCount,
    RocketDamage, RocketSplashRadius, RocketMaxCount,
    AutorifleDamage, AutorifleCulldown,
    PlayerSpeed,
    JetpackForce, JetpackCulldown;
}

[Serializable]
public struct Purchase
{
    [SerializeField] int maxLevel, currentLevel, cost, costProgress;
    [SerializeField] float firstValue, addValue;
}
