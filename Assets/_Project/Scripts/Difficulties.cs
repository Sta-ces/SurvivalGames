using UnityEngine;

public class Difficulties : SimpleSingleton<Difficulties>  {

	[Header("Difficulties")]
	public int HowMuchKilled = 50;
	[Range(1,20)]
	public float ValueDifficulties = .25f;


	public void GrowDifficulties(){
		if(Spawning.Instance.GetSecondsToSpawn > Spawning.Instance.GetMinSecondsToSpawn){
			Spawning.Instance.GetSecondsToSpawn -= ValueDifficulties;
			if(Spawning.Instance.GetSecondsToSpawn < Spawning.Instance.GetMinSecondsToSpawn)
				Spawning.Instance.GetSecondsToSpawn = Spawning.Instance.GetMinSecondsToSpawn;
		}
	}
}
