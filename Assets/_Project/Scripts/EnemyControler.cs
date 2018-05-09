using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControler : SimpleSingleton<EnemyControler> {

	public int m_Life = 10;
	[Range(1,20)]
	public float m_Speed = 3.5f;
	public int m_GivePieces = 25;

	[Header("Death")]
	public UnityEvent Death;


	public int LifeEnemy{
		get{ return m_Life; }
		set{ m_Life -= value; }
	}

	public float SpeedEnemy{
		get{ return m_Speed; }
		set{ m_Speed += value; }
	}


	private void LateUpdate(){
		GetComponent<NavMeshAgent>().speed = EnemyControler.Instance.SpeedEnemy;

		if( !CharacterControler.Instance.DeathPlayer )
			GetComponent<NavMeshAgent>().SetDestination(CharacterControler.Instance.transform.position);
		else
			GetComponent<NavMeshAgent>().SetDestination(transform.position);

		CheckLife();
	}
		

	private void CheckLife(){
		if( m_Life <= 0 ){
			Death.Invoke();
			Destroy(gameObject);

			Score.Instance.AddPieces(m_GivePieces);
			Score.Instance.AddScore();
			Display.Instance.DisplayAllScoring();
		}
	}
}
