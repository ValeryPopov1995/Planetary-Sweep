using System;
using UnityEngine;

[SerializeField]
[CreateAssetMenu(fileName = "Purchases", menuName = "Scriptable/Purchases", order = 1)]
public class PurchasesConfig : ScriptableObject
{
    [SerializeField] public PurchaseConfig[] Purchases;
    int _cash;
    public event Action CashChanged;
    
    public int Cash
    {
        get { return _cash; }
        set
        {
            if (value > 0) _cash = value;
            else _cash = 0;
            CashChanged?.Invoke();
        }
    }
}
