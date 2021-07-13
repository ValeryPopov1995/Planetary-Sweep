using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class UI_PurchaseButton : MonoBehaviour
{
    [SerializeField] PurchaseConfig _purchase;
    [SerializeField] LayoutElement _element;
    [SerializeField] LayoutGroup _elementGroup;

    Button _button;

    void Start()
    {
        if (_purchase.ParentPurchase != null) _purchase.ParentPurchase.UpdatePurchaseLevel += updateButton;

        _button = GetComponent<Button>();

        for (int i = 1; i < _purchase.MaxLevel; i++) Instantiate(_element.gameObject, _elementGroup.transform);

        updateButton();
    }

    public void UpgradeLevel()
    {
        if (Settings.Singleton.Purchases.Cash < _purchase.Cost) return;
        
        Settings.Singleton.Purchases.Cash -= _purchase.Cost;
        _purchase.LevelUp();
        updateButton();
    }

    void updateButton()
    {
        var papa = _purchase.ParentPurchase;
        if (papa != null && papa.Level == 0) _button.interactable = false;
        else if (_purchase.Level == _purchase.MaxLevel) _button.interactable = false;
        else _button.interactable = true;
    }
}
