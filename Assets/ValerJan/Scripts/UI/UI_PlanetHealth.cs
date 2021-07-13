using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_PlanetHealth : MonoBehaviour
{
    Text _text;
    float _value, _maxValue;

    void Start()
    {
        EventHolder.Singlton.PlanetAddMaxHealth += addValue;
        EventHolder.Singlton.PlanetChangeHealth += takeDamage;

        _text = GetComponent<Text>();
    }

    void addValue(System.Object obj)
    {
        _maxValue += (float)obj;
        _value = _maxValue;
    }

    void takeDamage(float damage)
    {
        _value -= damage;
        int per = (int) (_value / _maxValue * 100);
        _text.text = per + "%";
    }
}
