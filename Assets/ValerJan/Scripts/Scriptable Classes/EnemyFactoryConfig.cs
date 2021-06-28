using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Factory Settings", menuName = "Scriptable/Enemy Factory Settings", order = 1)]
public class EnemyFactoryConfig : ScriptableObject
{
    public GameObject SimpleWarrior, WarriorBoss;
    public GameObject[] DeploySystems;
    public GameObject[] FactorySystems; // завод по производству роботов на поверхности планеты
}
