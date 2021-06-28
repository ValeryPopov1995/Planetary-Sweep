using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [HideInInspector] public float PlanetaryHealth { get; private set; }
    public PlanetaryWavesConfig PlanetaryWaves;
    public Transform StartPlayerPosition;
    public Transform[] DeployPoints;

    void Start()
    {
        EventHolder.Singlton.PlanetAddMaxHealth += addHealth;
        EventHolder.Singlton.PlanetTakeDamage += takeDamage;

        if (DeployPoints.Length == 0) Debug.LogError("нет точек десантирования");
        foreach(var e in DeployPoints)
        {
            Vector3 targetDir = (e.position - transform.position).normalized;
            e.rotation = Quaternion.FromToRotation(e.up, targetDir);
        }
    }

    public void Attract(Transform body)
    {
        Vector3 targetDir = (body.position - transform.position).normalized;
        body.rotation = Quaternion.FromToRotation(body.up, targetDir) * body.rotation;
    }

    void addHealth(System.Object obj)
    {
        PlanetaryHealth += (float)obj;
    }

    void takeDamage(System.Object obj)
    {
        PlanetaryHealth -= (float)obj;
        if (PlanetaryHealth <= 0) EventHolder.Singlton.DefeatGame?.Invoke(null);
    }
}
