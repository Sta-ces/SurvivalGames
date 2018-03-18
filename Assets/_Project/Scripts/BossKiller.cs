using UnityEngine;

public class BossKiller : SimpleSingleton<BossKiller> {

	public int m_LevelToUnlock;

	public void BossKilled(){
		Levels.Instance.PauseGame ();
		Display.Instance.SetDisplayWinner(true);
		Levels.Instance.SetLevelsAdventure(m_LevelToUnlock);
	}
}
