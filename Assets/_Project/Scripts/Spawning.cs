using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : Singleton<Spawning> {

	[Header("Boss")]
	public GameObject m_BossPrefabs;
	public Transform m_BossSpawner;

	[Header("Robots")]
	public GameObject m_RobotsPrefabs;
	public Transform[] m_RobotsSpawners;

	[Header("Enemy Wave")]
	public int m_NumberRobots = 50;
	[Range(0.1f, 10f)]
	public float m_SecondsToSpawn = 1f;


	public int GetCountSpawners(){ return m_RobotsSpawners.Length; }
	public float GetSecondsToSpawn(){ return m_SecondsToSpawn; }
	public Transform[] GetArraySpawners(){ return m_RobotsSpawners; }


	public IEnumerator StartSpawnRobots(int _numMaxEnemy){
		for(int enemy = 0; enemy < _numMaxEnemy; enemy++){
			yield return new WaitForSeconds(m_SecondsToSpawn);
			int random = Random.Range(1, m_RobotsSpawners.Length);
			Instantiate(m_RobotsPrefabs, m_RobotsSpawners[random].position, m_RobotsSpawners[random].rotation);
		}
		
		isBoss = true;
	}

	public void SpawnBoss(){
		Instantiate(m_BossPrefabs, m_BossSpawner.position, m_BossSpawner.rotation);
		isBoss = false;
	}


	private void Start(){
		if( m_RobotsSpawners.Length > 0 )
			StartCoroutine(StartSpawnRobots(m_NumberRobots));
		else Debug.LogError("No Spawner is set.");
	}

	private void Update(){
		if( isBoss && GameObject.FindGameObjectsWithTag(m_RobotsPrefabs.tag).Length <= 0 )
			SpawnBoss();
	}


	private bool isBoss = false;
}
