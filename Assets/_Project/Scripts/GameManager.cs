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

    private static bool onPlay = false;
    public static bool OnPlay
    {
        get { return onPlay; }
        set { onPlay = value; }
    }

	public void PauseGame(){
		Time.timeScale = (Time.timeScale == 1) ? 0 : 1;
		GameManager.IsPaused = (Time.timeScale == 1) ? true : false;
	}

	public void RestartGame(bool _restart){
		GameManager.Restart = _restart;
	}

    public void OnPlaying(bool _play) { onPlay = _play; }

	private void OnEnable(){
		Cursor.visible = MouseVisibility;
		Cursor.lockState = CursorLockMode.Confined;
	}
}
