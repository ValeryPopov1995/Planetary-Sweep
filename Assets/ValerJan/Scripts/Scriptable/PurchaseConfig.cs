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

    public event Action UpdatePurchaseLevel; // for purchase button

    public int Cost { get { return startCost + costProgress * currentLevel;}}
    public float Value { get { return firstValue + addValue * currentLevel; }}

    public int MaxLevel
    {
        get { return maxLevel; }
        private set
        {
            if (value <= 0) maxLevel = 1;
            else maxLevel = value;
        }
    }

    public int Level { get { return currentLevel;} }

    public void ResetLevel()
    {
        currentLevel = defaultLevel;
    }

    public void LevelUp()
    {
        if (currentLevel == maxLevel) return;

        currentLevel++;
        UpdatePurchaseLevel?.Invoke();
    }
}
