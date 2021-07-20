using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLoader : MonoBehaviour
{
    void Awake()
    {
        var p = Settings.LoadingPlanet;
        Instantiate(p, Vector3.zero, Quaternion.identity);
    }
}
