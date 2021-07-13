using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable/Game Settingss", order = 1)]
public class GameSettingsConfig : ScriptableObject
{
    public float VolumeEffects;
    public float VolumeMusic;
    public float Sensetivity;
    public int DropdownFPS = 1;

    public GameObject LoadingPlanet;
}
