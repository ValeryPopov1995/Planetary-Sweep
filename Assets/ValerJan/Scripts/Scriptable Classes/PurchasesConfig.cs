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
    PlayerSpeed, PlayerHealth,
    JetpackForce, JetpackCulldown;
}

[Serializable]
public struct Purchase
{
    [SerializeField] int maxLevel, currentLevel, cost, costProgress;
    [SerializeField] float firstValue, addValue;

    public int CurrentLevel
    {
        get { return currentLevel;}
        set
        {
            if (value > maxLevel) currentLevel = maxLevel;
            else if (value < 0) currentLevel = 0;
            else currentLevel = value;
        }
    }
    public int CurrentCost { get { return cost + costProgress * currentLevel;}}
    public float CurrentValue { get { return firstValue + addValue * currentLevel;}}
}
