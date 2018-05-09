using UnityEngine;
using UnityEngine.Events;

public class PressToStart : MonoBehaviour {

	public bool CheckIfRestart = false;

	public UnityEvent OnPress;
	public UnityEvent OnQuit;

	void Update () {
		bool _check = (CheckIfRestart && GameManager.Restart);

		if(Controls.Submit || _check) OnPress.Invoke();
		if(Controls.Cancel) OnQuit.Invoke();
	}
}
