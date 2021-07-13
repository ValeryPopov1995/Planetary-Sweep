using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Purchases", menuName = "Scriptable/Purchases", order = 1)]
public class PurchasesConfig : ScriptableObject
{
    public int Cash;
    public PurchaseConfig[] Purchases;
}
