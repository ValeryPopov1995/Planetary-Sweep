using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CursorAmmo : MonoBehaviour
{
    [SerializeField] PurchaseConfig _purchaseAmmo;
    [SerializeField] GameObject _elementPrefab;
    GameObject[] _elements;

    void Start()
    {
        List<GameObject> elements = new List<GameObject>();
        for (int i = 0; i < (int)_purchaseAmmo.Value; i++)
        {
            var e = Instantiate(_elementPrefab, transform);
            elements.Add(e);
        }
        _elements = elements.ToArray();
        _elementPrefab.SetActive(false);
    }

    public void SetValue(int value)
    {
        for (int i = 0; i < _elements.Length; i++)
        {
            if (i < value) _elements[i].SetActive(true);
            else _elements[i].SetActive(false);
        }
    }
}