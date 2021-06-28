using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabFactory : MonoBehaviour
	{
		public static PrefabFactory FactorySinglton;
		
		public PrefabConfig PrefabsConfig;
		
		void Start()
		{
			if (FactorySinglton == null) FactorySinglton = this;
			else Destroy(this);
		}
	}
