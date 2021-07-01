using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
	{
		int _enemyCount;
		
		void Start()
		{
			EventHolder.Singlton.AddEnemyCount += addEnemy;
		}
		
		void addEnemy(int count)
		{
			_enemyCount += count;
			if (_enemyCount <= 0)
			{
				_enemyCount = 0;
				EventHolder.Singlton.CompleteWave?.Invoke();
			}
		}
	}
