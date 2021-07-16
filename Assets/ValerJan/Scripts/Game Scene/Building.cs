using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
	{
		[SerializeField] BuildingConfig _config;
		public GameObject FullBuild, HalfDamage; // TODO
		
		float _health;
		bool _halfDamaged = false;
		PrefabConfig _prefabs;
		
		void Start()
		{
			_health = _config.Health;
			tag = "Planetary Object";
			_prefabs = Settings.Singleton.Prefabs;

			EventHolder.Singleton.PlanetChangeHealth?.Invoke(_health);
		}
		
		public void TakeDamage(float damage)
		{
			if (damage > _health) damage = _health; // получение урона без избытка
			_health -= damage;
			EventHolder.Singleton.PlanetChangeHealth?.Invoke(-damage);

			if (_health <= 0) die();
			else if (!_halfDamaged && _health < _config.Health / 2)
			{
				_halfDamaged = true;
				Instantiate(_prefabs.Boom, transform.position, transform.rotation);
			}
		}
		
		void die()
		{
			Instantiate(_prefabs.Boom, transform.position, transform.rotation);
			Instantiate(_prefabs.Ruins, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
