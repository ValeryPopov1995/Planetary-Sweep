using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameBalanceConfig GameBalance;
    public PurchasesConfig Purchases, DefaultPurchases;
    public GameSettingsConfig GameSettings;
    public static Settings Singleton;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);

        Application.targetFrameRate = GameSettings.DropdownFPS;
    }
}
