using UnityEngine;
using System;

public class EventHolder : MonoBehaviour
{
    public static EventHolder Singleton;

    public Action UseRocket, UseGranate, UseShotgun, UseJetPack, CompleteWave;
    public Action<bool> EndGame; // true - victory
    public Action<int> AddEnemyCount;
    public Action<Planet> PlanetLoaded;

    public Action<string> Massage;

    public Action<float> PlanetChangeHealth, PlayerChangeHealth;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);
    }
}
