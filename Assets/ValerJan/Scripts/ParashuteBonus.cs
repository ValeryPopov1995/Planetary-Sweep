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
        rb = GetComponent<Rigidbody>();
        sphere = GetComponent<SphereCollider>();
        if (!sphere.isTrigger) sphere.isTrigger = true;
    }

    void FixedUpdate()
    {
        var gravity = (Vector3.zero - transform.position).normalized;
        rb.velocity = gravity * _parashuteSpeed;
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
