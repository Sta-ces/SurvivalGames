using UnityEngine;
using UnityEngine.Events;

public class PressToStart : MonoBehaviour {

	public bool CheckIfRestart = false;

	public UnityEvent OnPress;
	public UnityEvent OnQuit;

    public void ActiveOnPress() { OnPress.Invoke(); }

	void FixedUpdate () {
        if (!DeleteSave.Instance.IsOpen)
        {
            //bool _check = (CheckIfRestart && GameManager.Restart && Score.Instance.GetLastScore >= 5);

            if (Controls.Submit) OnPress.Invoke();
            if (Controls.Cancel) OnQuit.Invoke();
        }
    }
}
