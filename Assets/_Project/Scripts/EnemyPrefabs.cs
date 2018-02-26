using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyPrefabs : MonoBehaviour {

	public static EnemyPrefabs instance;


	public int GetLifeEnemy(){
		return m_life;
	}

	public void SetLifeEnemy(int _damage){
		m_life -= _damage;
	}

	public float GetSpeedEnemy(){
		return m_speed;
	}


	private void Awake() {
		if( instance != null ){
			Destroy(instance);
			return;
		}

		instance = this;


		CreatedEnemies enemy = new CreatedEnemies(Bullets.instance.DamageBullet(), CharacterControler.instance.GetSpeedCharacter());
		m_life = enemy.Life;
		m_speed = enemy.Speed;
	}

	private void LateUpdate(){
		GetComponent<NavMeshAgent>().SetDestination(FindObjectOfType<CharacterControler>().transform.position);
	}


	private int m_life;
	private float m_speed;
}
