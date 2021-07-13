using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Scriptable/Enemy Wave", order = 1)]
	public class EnemyWaveConfig : ScriptableObject
	{
		public EnemyInWave[] SpaceshipCounts;
	}
	
	[Serializable]
	public class EnemyInWave
	{
		public GameObject SpaceshipPrefab; // или public EnemyBageviour
		public int Count;
	}
