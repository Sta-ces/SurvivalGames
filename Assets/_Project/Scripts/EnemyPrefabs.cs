using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPrefabs : Singleton<EnemyPrefabs> {

	public int GetLifeEnemy(){
		return m_life;
	}

	public void SetLifeEnemy(int _damage){
		m_life -= _damage;
	}

	public float GetSpeedEnemy(){
		return m_speed;
	}


	private void Start(){
		CreatedEnemies enemy = new CreatedEnemies(Bullets.Instance.DamageBullet(), CharacterControler.Instance.GetSpeedCharacter());
		m_life = enemy.Life;
		m_speed = enemy.Speed;
	}

	private void LateUpdate(){
		GetComponent<NavMeshAgent>().speed = m_speed;
		GetComponent<NavMeshAgent>().SetDestination(CharacterControler.Instance.transform.position);
	}


	private int m_life;
	private float m_speed;
}
