using UnityEngine;

public class Difficulties : SimpleSingleton<Difficulties>  {

	[Header("Difficulties")]
	public int HowMuchKilled = 50;
	[Range(1,20)]
	public float ValueDifficulties = .25f;


	public void GrowDifficulties(){
        if (Spawning.Instance.GetSecondsToSpawn > Spawning.Instance.GetMinSecondsToSpawn) {
            Spawning.Instance.GetSecondsToSpawn -= ValueDifficulties;
            if (Spawning.Instance.GetSecondsToSpawn < Spawning.Instance.GetMinSecondsToSpawn)
                Spawning.Instance.GetSecondsToSpawn = Spawning.Instance.GetMinSecondsToSpawn;
        }
        else if (EnemyCapacity.SpeedEnemy < EnemyControler.Instance.MaxSpeedEnemy)
        {
            if (!CoolDown.IsCoolDown)
            {
                if (EnemyCapacity.SpeedEnemy == 0)
                    EnemyCapacity.SpeedEnemy = EnemyControler.Instance.SpeedBase + ValueDifficulties;
                else EnemyCapacity.SpeedEnemy += ValueDifficulties;

                if (EnemyCapacity.SpeedEnemy > EnemyControler.Instance.MaxSpeedEnemy)
                    EnemyCapacity.SpeedEnemy = EnemyControler.Instance.MaxSpeedEnemy;
            }
        }
	}

    public void ChangeHowMuchKilled(int _number)
    {
        HowMuchKilled = _number;
    }
}
