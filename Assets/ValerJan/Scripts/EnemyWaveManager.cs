using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
	{
		PlanetaryWavesConfig ScriptableWaves;
		Planet planet;
		Dictionary<Transform, bool> spownPointsIsFree = new Dictionary<Transform, bool>();
		int index;
		
		void Start()
		{
			ScriptableWaves = FindObjectOfType<Planet>().PlanetaryWaves;
			planet = FindObjectOfType<Planet>();
			EventHolder.Singlton.CompleteWave += waveComplete;

			foreach(var e in planet.DeployPoints) spownPointsIsFree.Add(e, true); // all points are free to deploy
			StartCoroutine(nextWave()); // TODO начало сразу, но можно подумать
		}
		
		void waveComplete()
		{
			Debug.Log("wave # " + index + " complete");

			index++;
			if (index <= ScriptableWaves.Waves.Length) StartCoroutine(nextWave());
			else EventHolder.Singlton.VictoryGame?.Invoke();
		}
		
		IEnumerator nextWave()
		{
			Debug.Log("wave # " + index + " begining");

			yield return new WaitForSeconds(Settings.Singleton.GameBalance.EnemyWaveCullback);
			EventHolder.Singlton.Massage?.Invoke("Наступает новая волна!");
			
			// список всех создаваемых префабов за данную волну, все в одной куче
			List<GameObject> spownList = new List<GameObject>();
			foreach (var e in ScriptableWaves.Waves[index].SpaceshipCounts)
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
			foreach(var e in spownPointsIsFree) if (e.Value == true) freePoints.Add(e.Key);

			if (freePoints.Count == 0) return false; // have no free deploy point

			freeDeployPoint = freePoints[Random.Range(0, freePoints.Count)];
			spownPointsIsFree[freeDeployPoint] = false;
			StartCoroutine(setDeployPointFree(freeDeployPoint));

			return true;
		}

		IEnumerator setDeployPointFree(Transform deployPoint)
		{
			yield return new WaitForSeconds(Settings.Singleton.GameBalance.TimerDestroySpaceships);
			spownPointsIsFree[deployPoint] = true;
		}
	}
