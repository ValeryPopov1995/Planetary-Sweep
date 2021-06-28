using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public GameConfig GamePlaySets;
    public PlayerConfig PlayerSets;
    public static Settings Singleton;

    void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this);

        Application.targetFrameRate = GamePlaySets.TargetFPS;
    }
}
