using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
	{
		int enemyCounter;
		
		void Start()
		{
			EventHolder.Singlton.AddEnemyCount += addEnemy;
		}
		
		void addEnemy(System.Object obj)
		{
			enemyCounter += (int)obj;
			if (enemyCounter <= 0)
			{
				enemyCounter = 0;
				EventHolder.Singlton.CompleteWave?.Invoke(null);
			}
		}
	}
