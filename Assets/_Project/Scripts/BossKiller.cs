using UnityEngine;

public class BossKiller : SimpleSingleton<BossKiller> {


	public void BossKilled(){
		Levels.Instance.PauseGame ();
		Display.Instance.SetDisplayWinner(true);
		Levels.Instance.SetLevelsAdventure(Levels.Instance.GetLevelsAdventure()+1);
	}
}
