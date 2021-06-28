using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class AmmoCounter : MonoBehaviour
{
    public Ammo Rockets, Granates, RifleMagazine;

    void OnTriggerEnter(Collider other)
    {
        var bonus = other.GetComponent<ParashuteBonus>();
        if (bonus != null)
        {
            if (Granates.ChangeAmmo(bonus.AddValue)) EventHolder.Singlton.GetGranate(Granates.CurrentValue);
        }
    }
}

public class Ammo
{
    public int MaxValue {get; private set;} = 3;
    public int CurrentValue {get; private set;} = 3;

    public bool ChangeAmmo(int value)
    {
        int current = CurrentValue;
        if (value != 0)
        {
            current += value;
            if (current > MaxValue) current = MaxValue;
            else if (current < 0) current = 0;

            if (current != CurrentValue)
            {
                CurrentValue = current;
                return true;
            }
        }
        return false;
    }
}
