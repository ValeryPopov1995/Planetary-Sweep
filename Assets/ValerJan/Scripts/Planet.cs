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
        EventHolder.Singlton.PlanetChangeHealth += takeDamage;

        if (DeployPoints.Length == 0) Debug.LogError("нет точек десантирования");
        foreach(var e in DeployPoints)
        {
            Vector3 targetDir = (e.position - transform.position).normalized;
            e.rotation = Quaternion.FromToRotation(e.up, targetDir);
        }

        EventHolder.Singlton.PlanetLoaded(this);
    }

    void addHealth(System.Object obj)
    {
        PlanetaryHealth += (float)obj;
    }

    void takeDamage(float damage)
    {
        PlanetaryHealth -= (float)damage;
        if (PlanetaryHealth <= 0) EventHolder.Singlton.DefeatGame?.Invoke();
    }
}
