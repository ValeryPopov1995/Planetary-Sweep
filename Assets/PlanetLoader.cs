using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetLoader : MonoBehaviour
{
    void Start()
    {
        var p = Settings.Singleton.GameSettings.LoadingPlanet;
        Instantiate(p, Vector3.zero, Quaternion.identity);
    }
}
