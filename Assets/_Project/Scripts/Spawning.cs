using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawning : SimpleSingleton<Spawning> {

	[Header("Boss")]
	public GameObject m_BossPrefabs;
	public Transform m_BossSpawners;

	[Header("Robots")]
	public GameObject m_RobotsPrefabs;
	public Transform[] m_RobotsSpawners;

	[Header("Enemy Wave")]
	public bool Infinite = false;
	public int m_NumberRobots = 50;
	[Range(0.1f, 10f)]
	public float m_SecondsToSpawn = 1f;

	[Header("Active Boss")]
	public UnityEvent ActivateBoss;


	public int GetNumberRobots{
		get{ return m_NumberRobots; }
		set{ m_NumberRobots = value; }
	}

	public int GetCountSpawners{
		get{ return m_RobotsSpawners.Length; }
	}

	public float GetSecondsToSpawn{
		get{ return m_SecondsToSpawn; }
		set{ m_SecondsToSpawn = value; }
	}

	public Transform[] GetArraySpawners{
		get{ return m_RobotsSpawners; }
	}

	private bool isBoss = false;
	public bool IsBoss {
		get{ return isBoss; }
		set{ isBoss = value; }
	}


	public IEnumerator SpawnRobots(int _numMaxEnemy){
		int enemy = 0;
		while(!CharacterControler.Instance.DeathPlayer && enemy < _numMaxEnemy){
			yield return new WaitForSeconds(Spawning.Instance.GetSecondsToSpawn);
			int random = Random.Range(1, Spawning.Instance.GetCountSpawners);
			Instantiate(m_RobotsPrefabs, Spawning.Instance.GetArraySpawners[random].position, Spawning.Instance.GetArraySpawners[random].rotation);
			if(!Infinite) enemy++;
			Spawning.Instance.IsBoss = enemy >= _numMaxEnemy ? true : false;
		}
	}

	public IEnumerator SpawnBoss(){
		Spawning.Instance.IsBoss = false;
		yield return new WaitForSeconds(Spawning.Instance.GetSecondsToSpawn);
		ActivateBoss.Invoke();
	}


	private void Start(){
		if (Spawning.Instance.GetCountSpawners > 0)
			StartCoroutine(SpawnRobots (Spawning.Instance.GetNumberRobots));
	}

	private void LateUpdate(){
		if( Spawning.Instance.IsBoss && GameObject.FindGameObjectsWithTag(m_RobotsPrefabs.tag).Length <= 0 )
			StartCoroutine(SpawnBoss());
	}
}
