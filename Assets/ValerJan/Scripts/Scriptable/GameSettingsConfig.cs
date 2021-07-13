using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable/Game Settingss", order = 1)]
public class GameSettingsConfig : ScriptableObject
{
    public float VolumeEffects, VolumeMusic, Sensetivity = 100;
    public int DropdownFPS = 60;

    public GameObject LoadingPlanet;
}
