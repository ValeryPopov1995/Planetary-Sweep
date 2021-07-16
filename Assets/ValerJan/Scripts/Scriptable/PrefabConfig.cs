using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Prefabs config", menuName = "Scriptable/Prefabs config", order = 1)]
	public class PrefabConfig : ScriptableObject
	{
		public GameObject Ruins, Boom,
		AutoriflePrefab;
		public GameObject[] Bonuses;
	}