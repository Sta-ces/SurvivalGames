using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool MouseVisibility = true;

	private static bool restart = false;
	public static bool Restart{
		get{ return restart; }
		set{ restart = value; }
	}

	private static bool isPaused = false;
	public static bool IsPaused{
		get{ return isPaused; }
		set{ isPaused = value; }
	}

	public void PauseGame(){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
		GameManager.IsPaused = (Time.timeScale == 1) ? true : false;
	}

	public void RestartGame(bool _restart){
		GameManager.Restart = _restart;
	}

	private void OnEnable(){
		PauseGame();
		Cursor.visible = MouseVisibility;
		Cursor.lockState = CursorLockMode.Confined;
	}
}
