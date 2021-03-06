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
        if (enemies.Length == 0) return;

        foreach(var e in enemies)
        {
            var component = e.gameObject.GetComponent<AIHealth>();
            if (component == null)
                Debug.LogError("противник не имеет компонента EnemyBaheviour");
            
            component.TakeDamage(_purchaseDamage.Value);
        }
    }
}
