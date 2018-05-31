using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawning : SimpleSingleton<Spawning> {

	[Header("Boss")]
	public GameObject BossPrefabs;
	public Transform BossSpawners;

	[Header("Robots")]
	public GameObject RobotsPrefabs;
	public Transform[] RobotsSpawners;

	[Header("Enemy Wave")]
	public bool Infinite = false;
	public int NumberRobots = 50;
	[Range(.1f, 10f)]
	public float SecondsToSpawn = 1f;
	[Range(.1f, 5f)]
	public float MinSecondsToSpawn = .1f;

	[Header("Active Boss")]
	public UnityEvent ActivateBoss;


	public int GetNumberRobots{
		get{ return NumberRobots; }
		set{ NumberRobots = value; }
	}

	public int GetCountSpawners{
		get{ return RobotsSpawners.Length; }
	}

	public float GetSecondsToSpawn{
		get{ return SecondsToSpawn; }
		set{ SecondsToSpawn = value; }
	}

	public float GetMinSecondsToSpawn{
		get{ return MinSecondsToSpawn; }
	}

	public Transform[] GetArraySpawners{
		get{ return RobotsSpawners; }
	}

	private bool isBoss = false;
	public bool IsBoss {
		get{ return isBoss; }
		set{ isBoss = value; }
	}

    private bool isFinish = false;
    public bool IsFinish
    {
        get { return isFinish; }
        set { isFinish = value; }
    }


	public IEnumerator SpawnRobots(int _numMaxEnemy){
		int enemy = 0;
		while(!CharacterControler.Instance.DeathPlayer && enemy < _numMaxEnemy){
			yield return new WaitForSeconds(Spawning.Instance.GetSecondsToSpawn);
            if (!GameManager.IsPaused)
            {
                int random = Random.Range(1, Spawning.Instance.GetCountSpawners);
                Instantiate(RobotsPrefabs, Spawning.Instance.GetArraySpawners[random].position, Spawning.Instance.GetArraySpawners[random].rotation);
                if (!Infinite) enemy++;
                if (BossPrefabs != null)
                    Spawning.Instance.IsBoss = enemy >= _numMaxEnemy;
                IsFinish = enemy >= _numMaxEnemy;
            }
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
		if( Spawning.Instance.IsBoss && GameObject.FindGameObjectsWithTag(RobotsPrefabs.tag).Length <= 0 )
			StartCoroutine(SpawnBoss());
	}
}
