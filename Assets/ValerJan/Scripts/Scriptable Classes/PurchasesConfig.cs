using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Purchases", menuName = "Scriptable/Purchases", order = 1)]
public class PurchasesConfig : ScriptableObject
{
    public PurchaseConfig[] Purchases;
}
