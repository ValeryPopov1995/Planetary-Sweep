using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
	{
		public BuildingConfig Config;
		public GameObject FullBuild, HalfDamage;
		
		float health;
		bool halfDamaged = false;
		
		void Start()
		{
			health = Config.Health;
			tag = "Planetary Object";

			EventHolder.Singlton.PlanetAddMaxHealth?.Invoke(health);
		}
		
		public void TakeDamage(float damage)
		{
			health -= damage;
			EventHolder.Singlton.PlanetTakeDamage?.Invoke(damage); // TODO может отнять здоровья с избытком

			if (health <= 0) die();
			else if (!halfDamaged && health < Config.Health / 2)
			{
				halfDamaged = true;
				Instantiate(PrefabFactory.FactorySinglton.PrefabsConfig.boom, transform.position, transform.rotation);
			}
		}
		
		void die()
		{
			Instantiate(PrefabFactory.FactorySinglton.PrefabsConfig.boom, transform.position, transform.rotation);
			Instantiate(PrefabFactory.FactorySinglton.PrefabsConfig.ruins, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
