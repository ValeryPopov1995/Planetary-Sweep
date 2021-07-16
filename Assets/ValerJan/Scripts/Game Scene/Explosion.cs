using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] LayerMask _layerMask;
    [SerializeField] PurchaseConfig _purchaseDamage;
    [SerializeField] PurchaseConfig _purchaseRadius;

    void Start()
    {
        explose();
    }

    private void explose()
    {
        var enemies = Physics.OverlapSphere(transform.position, _purchaseRadius.Value, _layerMask, QueryTriggerInteraction.Ignore);
        Debug.Log(enemies.Length);
        if (enemies.Length == 0) return;

        foreach(var e in enemies)
        {
            EnemyBaheviour component = e.gameObject.GetComponentInChildren<EnemyBaheviour>();
            if (component == null)
                Debug.LogError("противник не имеет компонента EnemyBaheviour");
            
            component.TakeDamage(_purchaseDamage.Value);
        }
    }
}
