using UnityEngine;
using Rewired;

public class GamePadInputs : MonoBehaviour {


	private Player m_playerInput;
	public Player PlayerInput{
		get{ return m_playerInput; }
		set{ m_playerInput = value; }
	}


	private void Start(){
		PlayerInput = ReInput.players.GetPlayer(0);
	}

	private void Update(){
		SetControls();

		if( Controls.Mute )
        	MuteAllSounds.Instance.MuteSounds();
	}

	private void SetControls(){
		Controls.MoveX = PlayerInput.GetAxis ("MoveX");
		Controls.MoveZ = PlayerInput.GetAxis ("MoveZ");
		Controls.LookX = PlayerInput.GetAxis ("LookX");
		Controls.LookZ = PlayerInput.GetAxis ("LookZ");
		Controls.Pause = PlayerInput.GetButtonDown ("Pause");
		Controls.Shoot = PlayerInput.GetButtonDown ("Shoot");
		Controls.Reload = PlayerInput.GetButtonDown ("Reload");
		Controls.Submit = PlayerInput.GetButtonDown ("Submit");
		Controls.Cancel = PlayerInput.GetButtonDown ("Cancel");
		Controls.Mute = PlayerInput.GetButtonDown ("Mute");
	}
}
