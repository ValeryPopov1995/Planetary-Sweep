using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlanetaryWaves", menuName = "Scriptable/Planetary Waves", order = 1)]
	public class PlanetaryWavesConfig : ScriptableObject
	{
		public EnemyWaveConfig[] Waves;
	}
