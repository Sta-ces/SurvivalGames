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

    public float SpeedBase
    {
        get { return Speed; }
    }

	public float MaxSpeedEnemy{
		get{ return MaxSpeed; }
	}


    public void Killed()
    {
        Death.Invoke();
        Destroy(gameObject);
    }

    
    private void LateUpdate(){
        GetComponent<NavMeshAgent>().speed = (EnemyCapacity.SpeedEnemy == 0) ? SpeedBase : EnemyCapacity.SpeedEnemy;

        if ( !CharacterControler.Instance.DeathPlayer && !GameManager.IsPaused )
			GetComponent<NavMeshAgent>().SetDestination(CharacterControler.Instance.transform.position);
		else
			GetComponent<NavMeshAgent>().SetDestination(transform.position);

		CheckLife();
	}
		

	private void CheckLife(){
		if( Life <= 0 ){
            if (Calcul.RandomNumber(1, 8) == 1)
            {
                int _pieces = Calcul.RandomNumber(1, 4);
                Score.Instance.AddPieces(_pieces);
                Pieces.Invoke();
            }
            if (Spawning.Instance.IsInfinite) Score.Instance.AddScore();
            else Score.Instance.ReduceScore();
			Display.Instance.DisplayAllScoring();
            if(!CoolDown.IsCoolDown)
                CoolDown.CountingKill++;
            Shockwave.CountingKill++;
            if(!Endofthegame.IsSuperTiki)
                Endofthegame.CountingKill++;

            Killed();
		}
	}
}
