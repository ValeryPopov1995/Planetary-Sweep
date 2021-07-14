using UnityEngine;

public abstract class UseAmmo : MonoBehaviour
{
    [SerializeField] PurchaseConfig _purchaseAmmo;

    int _currentAmmo;

    void Start()
    {
        if (_purchaseAmmo.ParentPurchase != null && _purchaseAmmo.ParentPurchase.Level == 0) Destroy(gameObject);
        _currentAmmo = (int)_purchaseAmmo.Value; // Cast from outside of Hogvarts
    }

    public void TryUse()
    {
        if (_currentAmmo == 0) return;

        _currentAmmo--;
        Use();
    }

    protected abstract void Use();
}
