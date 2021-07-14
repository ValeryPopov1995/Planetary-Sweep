using UnityEngine;
using System;

public class EventHolder : MonoBehaviour
{
    public static EventHolder Singleton;

    public Action UseRocket, UseGranate, UseShotgun, UseJetPack, CompleteWave;
    public Action<bool> EndGame, PauseGame; // true - victory, pause
    public Action<int> AddEnemyCount;
    public Action<string> Massage;
    public Action<float> PlanetChangeHealth, PlayerChangeHealth;
    public Action<Planet> PlanetLoaded;
    public Action<ParashuteBonus> AddBonusAmmo;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);
    }
}
