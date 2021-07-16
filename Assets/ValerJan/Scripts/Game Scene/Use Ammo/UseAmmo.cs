using UnityEngine;

public abstract class UseAmmo : MonoBehaviour
{
    [SerializeField] PurchaseConfig _purchaseAmmo;
    [Tooltip("if != null this script use it")]
    [SerializeField] UI_CursorAmmo _cursorAmmo;

    int _currentAmmo;

    void Start()
    {
        EventHolder.Singleton.AddBonusAmmo += addAmmo;

        if (_purchaseAmmo.ParentPurchase != null && _purchaseAmmo.ParentPurchase.Level == 0)
        {
            if (_cursorAmmo != null) _cursorAmmo.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        _currentAmmo = (int)_purchaseAmmo.Value; // Cast from outside of Hogvarts
    }

    public void TryUse()
    {
        if (_currentAmmo == 0) return;

        _currentAmmo--;
        if (_cursorAmmo != null) _cursorAmmo.SetValue(_currentAmmo);
        Use();
    }

    void addAmmo(ParashuteBonus parashut)
    {
        if (parashut.Purchase != _purchaseAmmo) return;

        _currentAmmo += parashut.AddValue;
        if (_cursorAmmo != null) _cursorAmmo.SetValue(_currentAmmo);
        if (_currentAmmo > _purchaseAmmo.Value) _currentAmmo = (int)_purchaseAmmo.Value;
    }

    protected abstract void Use();
}
