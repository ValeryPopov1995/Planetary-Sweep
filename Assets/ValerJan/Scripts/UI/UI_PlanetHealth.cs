using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_PlanetHealth : MonoBehaviour
{
    Text _text;
    float _value, _maxValue;

    void Start()
    {
        EventHolder.Singleton.PlanetChangeHealth += changeHealth;

        _text = GetComponent<Text>();
    }

    void changeHealth(float value)
    {
        if (value > 0)
        {
            _value = _maxValue += value;
        }
        else // take damege
        {
            _value += value;
            int per = (int) (_value / _maxValue * 100);
            _text.text = per + "%";
        }
    }
}
