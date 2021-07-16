using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class ParashuteBonus : MonoBehaviour
{
    public PurchaseConfig Purchase;
    public int AddValue = 2;
    [SerializeField] int _parashuteSpeed = 10;
    SphereCollider sphere;
    Rigidbody rb;
    void Start()
    {
        if (Purchase.ParentPurchase != null && Purchase.ParentPurchase.Level == 0) Destroy(gameObject);

        rb = GetComponent<Rigidbody>();
        sphere = GetComponent<SphereCollider>();
        if (!sphere.isTrigger) sphere.isTrigger = true;
    }

    void FixedUpdate()
    {
        var gravity = (Vector3.zero - transform.position).normalized;
        //rb.velocity = gravity * _parashuteSpeed;
        rb.AddForce(gravity * _parashuteSpeed, ForceMode.Force);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EventHolder.Singleton.AddBonusAmmo?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
