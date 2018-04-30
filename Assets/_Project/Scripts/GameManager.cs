using UnityEngine;

public class GameManager : MonoBehaviour {

	private static bool isPaused = false;
	public static bool IsPaused{
		get{ return isPaused; }
		set{ isPaused = value; }
	}

	public void PauseGame(){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
		GameManager.IsPaused = (Time.timeScale == 1) ? true : false;
	}
}
