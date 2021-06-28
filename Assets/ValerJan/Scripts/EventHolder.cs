using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventHolder : MonoBehaviour
{
    public static EventHolder Singlton;

    public delegate void Action(System.Object obj);

    public Action UseRocket, UseGranate, UseShotgun, UseJetPack,
    GetRocket, GetGranate, GetShotgun, // TODO add free button
    AddEnemyCount, CompleteWave, VictoryGame, DefeatGame,
    Massage, PlanetAddMaxHealth, PlanetTakeDamage, PlayerChangeHealth;

    void Awake()
    {
        if (Singlton == null) Singlton = this;
        else Destroy(this);
    }
}
