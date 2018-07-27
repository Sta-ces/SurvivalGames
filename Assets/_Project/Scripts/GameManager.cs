using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour {

    [Header("Mouse Visibility")]
	public bool MouseGamepad = false;
    public bool MouseKeyboard = true;

    [Header("On Start Video Game")]
    public UnityEvent OnStart;

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

    public static bool IsAndroid
    {
        get { return Application.platform == RuntimePlatform.Android; }
    }

    public static bool IsIOS
    {
        get { return Application.platform == RuntimePlatform.IPhonePlayer; }
    }

	public void PauseGame(){
        GameManager.IsPaused = !GameManager.IsPaused;
	}

	public void RestartGame(bool _restart){
		GameManager.Restart = _restart;
	}

    public void OnPlaying(bool _play) { onPlay = _play; }

    public void CheckMouseVisibility()
    {
        Cursor.visible = GamePadInputs.Instance.IsGamepad ? MouseGamepad : MouseKeyboard;
    }

    private void Start()
    {
        CheckMouseVisibility();
		Cursor.lockState = CursorLockMode.Confined;
        OnStart.Invoke();
    }
}
