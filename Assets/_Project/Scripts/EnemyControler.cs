using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControler : Singleton<EnemyControler> {

	public int m_Life = 10;
	[Range(1,20)]
	public float m_Speed = 3.5f;


	public int GetLifeEnemy(){ return m_Life; }
	public float GetSpeedEnemy(){ return m_Speed; }

	public void SetLifeEnemy(int _damage){ m_Life -= _damage; }
	public void SetSpeedEnemy(float _speed){ m_Speed += _speed; }


	private void LateUpdate(){
		GetComponent<NavMeshAgent>().speed = m_Speed;

		if( CharacterControler.Instance.gameObject.activeSelf )
			GetComponent<NavMeshAgent>().SetDestination(CharacterControler.Instance.transform.position);
		else
			GetComponent<NavMeshAgent>().SetDestination(transform.position);

		CheckLife();
	}

	private void OnCollisionEnter(Collision col){
		if( col.gameObject == CharacterControler.Instance.gameObject ){
			col.gameObject.SetActive(false);
			Display.Instance.CharacterDead();
		}
	}


	private void CheckLife(){
		if( m_Life <= 0 ){
			Destroy(gameObject);
			Score.Instance.AddScore();

			if(GetComponent<BossKiller>())
				BossKiller.Instance.BossKilled();
		}
	}
}
