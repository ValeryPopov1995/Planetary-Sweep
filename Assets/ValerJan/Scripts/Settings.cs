using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameBalanceConfig GameBalance;
    public PurchasesConfig Purchases;
    public GameSettingsConfig GameSettings;
    public static Settings Singleton;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);
    }

    void Start()
    {
        EventHolder.Singleton.PauseGame += pauseGame;
        Application.targetFrameRate = 60;
    }

    void pauseGame(bool pause)
    {
        if (pause) Time.timeScale = 0;
        else Time.timeScale = 1;
    }
}
