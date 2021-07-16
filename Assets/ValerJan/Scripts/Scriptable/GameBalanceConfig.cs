using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Balance", menuName = "Scriptable/Game Balance", order = 1)]
public class GameBalanceConfig : ScriptableObject
{
    [ReadOnly]
    public float Gravity = 1000, EnemyWaveCullback = 5,
    SpaceshipSpownTime = 5, TimerDestroySpaceships = 5,
    AutoFireAngle = 9, AutoFireRange = 15,
    DefeatAwardCoeficient = .5f;

    public GameObject AutoriflePrefab;
}
