using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable/Game Settingss", order = 1)]
public class GameConfig : ScriptableObject
{
    public bool Granates = true, Rockets = true, Jetpack = true, Shotgun = true;
    public float Gravity = 1, EnemyWaveCullback = 5, SpaceshipSpownTime = 5, TimerDestroySpaceships = 5;
    public int TargetFPS = 60;
}
