using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_Cash : MonoBehaviour
{
    PurchasesConfig _purchases;
    Text _txt;

    void Start()
    {
        _txt = GetComponent<Text>();
        _purchases = Settings.Singleton.Purchases;
        showCash();

        if (_purchases != null) _purchases.CashChanged += showCash;
    }

    void OnEnable()
    {
        if (_purchases != null) showCash();
    }

    void showCash()
    {
        if (_txt != null && _purchases != null) _txt.text = _purchases.Cash.ToString();
    }
}
