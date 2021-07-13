using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHolder : MonoBehaviour
{
    public static EventHolder Singlton;

    public Action<Planet> PlanetLoaded;

    public Action UseRocket, UseGranate, UseShotgun, UseJetPack,
    CompleteWave, VictoryGame, DefeatGame;

    public Action<int> AddEnemyCount;

    public Action<string> Massage, PlanetAddMaxHealth;

    public Action<float> PlanetChangeHealth, PlayerChangeHealth;

    void Awake()
    {
        if (Singlton == null) Singlton = this;
        else Destroy(this);
    }
}
