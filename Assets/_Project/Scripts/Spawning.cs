using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : Singleton<Spawning> {

	public GameObject m_RobotsPrefabs;
	public Transform[] m_Spawners;
	[Range(1f, 10f)]
	public float m_SecondsToSpawn = 1f;


	public int GetCountSpawners(){
		return m_Spawners.Length;
	}

	public float GetSecondsToSpawn(){
		return m_SecondsToSpawn;
	}

	public Transform[] GetArraySpawners(){
		return m_Spawners;
	}

	public IEnumerator StartSpawnEnemy(int _numEnemy){
		for(int enemy = 0; enemy < _numEnemy; enemy++){
			yield return new WaitForSeconds(m_SecondsToSpawn);
			int random = Random.Range(1, GetCountSpawners());
			Instantiate(m_RobotsPrefabs, m_Spawners[random].position, m_Spawners[random].rotation);
		}
	}
}
