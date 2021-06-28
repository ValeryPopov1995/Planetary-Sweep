using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UI_PlanetHealth : MonoBehaviour
{
    Text txt;
    float value, maxValue;

    void Start()
    {
        EventHolder.Singlton.PlanetAddMaxHealth += addValue;
        EventHolder.Singlton.PlanetTakeDamage += takeDamage;

        txt = GetComponent<Text>();
    }

    void addValue(System.Object obj)
    {
        maxValue += (float)obj;
        value = maxValue;
    }

    void takeDamage(System.Object obj)
    {
        value -= (float)obj;
        int per = (int) (value / maxValue * 100);
        txt.text = per + "%";
    }
}
