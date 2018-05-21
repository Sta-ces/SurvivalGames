using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyControler : SimpleSingleton<EnemyControler> {

	public int Life = 10;
	[Range(1,20)]
	public float Speed = 3.5f;
	[Range(5,20)]
	public float MaxSpeed = 10f;

	[Header("Death")]
	public UnityEvent Death;

    [Header("Pieces")]
    public UnityEvent Pieces;


	public int LifeEnemy{
		get{ return Life; }
		set{ Life = value; }
	}

	public float SpeedEnemy{
		get{ return Speed; }
		set{ Speed = value; }
	}

	public float MaxSpeedEnemy{
		get{ return MaxSpeed; }
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
		if( Life <= 0 ){
            if (Calcul.RandomNumber(1, 6) == 1)
            {
                int _pieces = Calcul.RandomNumber(1, 4);
                Score.Instance.AddPieces(_pieces);
                Pieces.Invoke();
            }
			Score.Instance.AddScore();
			Display.Instance.DisplayAllScoring();

			Death.Invoke();
			Destroy(gameObject);
		}
	}
}
