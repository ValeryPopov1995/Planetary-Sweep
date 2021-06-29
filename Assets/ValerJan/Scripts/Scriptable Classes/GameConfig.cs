using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings", menuName = "Scriptable/Game Settingss", order = 1)]
public class GameConfig : ScriptableObject
{
    public float Gravity = 1000, EnemyWaveCullback = 5, SpaceshipSpownTime = 5, TimerDestroySpaceships = 5, AutoFireAngle = 9, AutoFireRange = 15,
    Sensetivity = 100;
    public int TargetFPS = 60;
    public GameObject AutoriflePrefab;
}
