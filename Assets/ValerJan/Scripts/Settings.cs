using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameBalanceConfig GameBalance;
    public PurchasesConfig Purchases;
    public GameSettingsConfig GameSettings;
    public PrefabConfig Prefabs;
    public static Settings Singleton;

    public static GameObject LoadingPlanet;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);
    }

    void Start()
    {
        if (EventHolder.Singleton != null) EventHolder.Singleton.PauseGame += pauseGame;
        Application.targetFrameRate = 60;
    }

    void pauseGame(bool pause)
    {
        if (pause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
