using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "New Purchase", menuName = "Scriptable/Purchase", order = 1)]
public class PurchaseConfig : ScriptableObject
{
    public PurchaseConfig ParentPurchase;
    [SerializeField] int maxLevel, currentLevel, defaultLevel, startCost, costProgress;
    [SerializeField] float firstValue, addValue;

    public int Cost { get { return startCost + costProgress * currentLevel;}}
    public float Value { get { return firstValue + addValue * currentLevel;}}

    public event Action UpdatePurchaseLevel; // for UI buttons

    public int MaxLevel
    {
        get { return maxLevel; }
        private set
        {
            if (value <= 0) maxLevel = 1;
            else maxLevel = value;
        }
    }

    public int Level
    {
        get { return currentLevel;}
        set
        {
            UpdatePurchaseLevel?.Invoke();

            if (value > maxLevel) currentLevel = maxLevel;
            else if (value < defaultLevel) currentLevel = defaultLevel;
            else currentLevel = value;
        }
    }

    public void ResetLevel()
    {
        Level = defaultLevel;
    }
}
