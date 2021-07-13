using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Balance", menuName = "Scriptable/Game Balance", order = 1)]
public class GameBalanceConfig : ScriptableObject
{
    public float Gravity = 1000, EnemyWaveCullback = 5, SpaceshipSpownTime = 5, TimerDestroySpaceships = 5, AutoFireAngle = 9, AutoFireRange = 15;
    public GameObject AutoriflePrefab;
}
