using UnityEngine;

public class PlanetLoader : MonoBehaviour
{
    void Start()
    {
        var p = Settings.LoadingPlanet;
        Instantiate(p, Vector3.zero, Quaternion.identity);
    }
}
