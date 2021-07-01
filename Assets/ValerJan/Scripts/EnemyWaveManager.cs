using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
	{
		PlanetaryWavesConfig _waves;
		Planet _planet;
		Dictionary<Transform, bool> _freeSpownPoints = new Dictionary<Transform, bool>();
		int _index;
		
		void Start()
		{
			_waves = FindObjectOfType<Planet>().PlanetaryWaves;
			_planet = FindObjectOfType<Planet>();
			EventHolder.Singlton.CompleteWave += waveComplete;

			foreach(var e in _planet.DeployPoints) _freeSpownPoints.Add(e, true); // all points are free to deploy
			StartCoroutine(nextWave()); // TODO начало сразу, но можно подумать
		}
		
		void waveComplete()
		{
			Debug.Log("wave # " + _index + " complete");

			_index++;
			if (_index <= _waves.Waves.Length) StartCoroutine(nextWave());
			else EventHolder.Singlton.VictoryGame?.Invoke();
		}
		
		IEnumerator nextWave()
		{
			Debug.Log("wave # " + _index + " begining");

			yield return new WaitForSeconds(Settings.Singleton.GameBalance.EnemyWaveCullback);
			EventHolder.Singlton.Massage?.Invoke("Наступает новая волна!");
			
			// список всех создаваемых префабов за данную волну, все в одной куче
			List<GameObject> spownList = new List<GameObject>();
			foreach (var e in _waves.Waves[_index].SpaceshipCounts)
			{
				for (int i = 0; i < e.Count; i++) spownList.Add(e.SpaceshipPrefab);
				yield return new WaitForEndOfFrame();
			}

			int limit = 1000;
			// создание десантных кораблей по одному
			while(spownList.Count > 0 && limit > 0)
			{
				limit--;

				Transform spownPos;
				if (getFreeSpownPoint(out spownPos))
				{
					Instantiate(spownList[0], spownPos.position, spownPos.rotation);
					Debug.Log(spownList[0].name + " spowned");
					spownList.RemoveAt(0);
				}
				yield return new WaitForSeconds(Settings.Singleton.GameBalance.SpaceshipSpownTime);
			}
			if (limit == 0) Debug.LogError("свободных точек десантирования кораблей не нашлось");
		}

		bool getFreeSpownPoint(out Transform freeDeployPoint)
		{
			freeDeployPoint = transform;
			List<Transform> freePoints = new List<Transform>(); // TODO SQL
			foreach(var e in _freeSpownPoints) if (e.Value == true) freePoints.Add(e.Key);

			if (freePoints.Count == 0) return false; // have no free deploy point

			freeDeployPoint = freePoints[Random.Range(0, freePoints.Count)];
			_freeSpownPoints[freeDeployPoint] = false;
			StartCoroutine(setDeployPointFree(freeDeployPoint));

			return true;
		}

		IEnumerator setDeployPointFree(Transform deployPoint)
		{
			yield return new WaitForSeconds(Settings.Singleton.GameBalance.TimerDestroySpaceships);
			_freeSpownPoints[deployPoint] = true;
		}
	}
