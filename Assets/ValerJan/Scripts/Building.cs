using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
	{
		public BuildingConfig Config;
		public GameObject FullBuild, HalfDamage;
		
		float _health;
		bool _halfDamaged = false;
		
		void Start()
		{
			_health = Config.Health;
			tag = "Planetary Object";

			EventHolder.Singlton.PlanetChangeHealth?.Invoke(_health);
		}
		
		public void TakeDamage(float damage)
		{
			if (damage > _health) damage = _health; // получение урона без избытка
			_health -= damage;
			EventHolder.Singlton.PlanetChangeHealth?.Invoke(-damage);

			if (_health <= 0) die();
			else if (!_halfDamaged && _health < Config.Health / 2)
			{
				_halfDamaged = true;
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
