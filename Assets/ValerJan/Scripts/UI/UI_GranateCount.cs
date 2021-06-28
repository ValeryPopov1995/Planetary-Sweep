using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GranateCount : MonoBehaviour
{
    void Start()
    {
        EventHolder.Singlton.GetGranate += setActiveElements;
    }

    void setActiveElements(System.Object obj)
    {
    }
}
// singlton, strategy, observer, decorator, factory
