using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UI_PurchaseButton : MonoBehaviour
{
    [SerializeField] PurchaseConfig _purchase;
    [SerializeField] LayoutElement _elementPrefab;
    [SerializeField] LayoutGroup _elementGroup;
    [SerializeField] Text _costText;
    [SerializeField] Color _onColor, _offColor;

    Image[] elements;

    Button _button;

    void Awake()
    {
        if (_purchase.ParentPurchase != null) _purchase.ParentPurchase.UpdatePurchaseLevel += updateButton;

        _button = GetComponent<Button>();

        elements = new Image[_purchase.MaxLevel];
        for (int i = 0; i < _purchase.MaxLevel; i++)
        {
            var e = Instantiate(_elementPrefab.gameObject, _elementGroup.transform);
            e.SetActive(true);
            elements[i] = e.GetComponent<Image>();
        }

        _elementPrefab.gameObject.SetActive(false);
    }

    void OnEnable() => updateButton();

    public void UpgradeLevel()
    {
        if (Settings.Singleton.Purchases.Cash < _purchase.Cost) return;
        
        Settings.Singleton.Purchases.Cash -= _purchase.Cost;
        _purchase.LevelUp();
        updateButton();
    }

    void updateButton()
    {
        bool interactable = false;

        var papa = _purchase.ParentPurchase;
        if (papa != null && papa.Level == 0) interactable = false;
        else if (_purchase.Level == _purchase.MaxLevel) interactable = false;
        else interactable = true;

        for (int i = 0; i < elements.Length; i++)
        {
            if (i < _purchase.Level)
            {
                if (elements[i] != null) elements[i].color = _onColor;
            }
            else
            {
                if (elements[i] != null) elements[i].color = _offColor;
            }
        }

        if (_costText != null) _costText.gameObject.SetActive(interactable);
        if (_costText != null) _costText.text = _purchase.Cost.ToString();
        if (_button != null) _button.interactable = interactable;
    }
}
