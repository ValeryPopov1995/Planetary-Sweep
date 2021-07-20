using UnityEngine;

public class UseJetpack : MonoBehaviour
{
    [SerializeField] PurchaseConfig _jetForce, _jetCallback;
    float _lastUseTime;

    void Start()
    {
        if (_jetForce.Level == 0) Destroy(gameObject);
        else _lastUseTime = Time.time;
    }

    public void TryUse()
    {
        if (_lastUseTime + _jetCallback.Value > Time.time) return;

        _lastUseTime = Time.time;
        EventHolder.Singleton.UseJetPack?.Invoke();
    }
}
