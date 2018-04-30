using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Boss : SimpleSingleton<Boss> {

	[Header("Info Boss")]
	public int m_Life = 1000;
	[Range(1,20)]
	public float m_Speed = 3.5f;
	public int m_TimeAttack = 5;
	public int m_GivePieces = 100;

	[Header("Points Attacks")]
	public List<Transform> m_PointsAttacks;

	public int LifeEnemy{
		get{ return m_Life; }
		set{ m_Life -= value; }
	}
	public float SpeedEnemy{
		get{ return m_Speed; }
		set{ m_Speed += value; }
	}

	[Header("Boss Hited")]
	public UnityEvent BossHit;

	[Header("Boss Killed")]
	public int m_LevelToUnlock;
	public UnityEvent BossDeath;


	public virtual void Attack(){}


	private void LateUpdate(){
		GetComponent<NavMeshAgent>().speed = Boss.Instance.SpeedEnemy;

		if ( !CharacterControler.Instance.DeathPlayer ) {
			if (!isAttack)
				if (m_destination == null || Vector3.Distance (transform.position, m_destination.position) - (transform.lossyScale.x * 2) <= 1)
					StartCoroutine ("AttackBoss");

			if (isAttack && CharacterControler.Instance.transform != null) {
				CharacterControler character = CharacterControler.Instance;
				Vector3 charPos = character.transform.position;
				Vector3 look = new Vector3 (charPos.x, transform.position.y, charPos.z);
				transform.LookAt (look);
			}
		}else{
			isAttack = false;
			GetComponent<NavMeshAgent>().destination = transform.position;
		}

		CheckLife();
	}


	private void MoveBoss(){
		m_destination = m_PointsAttacks [Random.Range (0, m_PointsAttacks.Count)];
		GetComponent<NavMeshAgent>().destination = m_destination.position;
	}

	private IEnumerator AttackBoss(){
		isAttack = true;

		int attack = 0;
		while (attack <= m_TimeAttack) {
			yield return new WaitForSeconds(1);
			Attack();
			attack++;
		}

		MoveBoss();

		isAttack = false;
	}

	private void CheckLife(){
		if (m_Life <= 0) {
			BossDeath.Invoke ();
			Destroy (gameObject);
			Score.Instance.AddPieces(m_GivePieces);
			Score.Instance.AddScore();
			Display.Instance.DisplayAllScoring();
		}
	}

	private Transform m_destination;
	private bool isAttack = false;
}
