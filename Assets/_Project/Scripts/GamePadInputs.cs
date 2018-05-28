using UnityEngine;
using Rewired;

public class GamePadInputs : SimpleSingleton<GamePadInputs> {

    [Header("Vibration Gamepad")]
    [Range(0,1)]
    public float MotorSpeed = .5f;
    [Range(0,1)]
    public float MotorDuration = 1f;


	private Player m_playerInput;
	public Player PlayerInput{
		get{ return m_playerInput; }
		set{ m_playerInput = value; }
	}

    public bool IsGamepad
    {
        get
        {
            bool _isGamepad = true;
            if (PlayerInput.controllers.GetLastActiveController() != null)
                _isGamepad = PlayerInput.controllers.GetLastActiveController().type == ControllerType.Joystick;
            return _isGamepad;
        }
    }


    public void VibrationGamepad()
    {
        PlayerInput.SetVibration(0, MotorSpeed, MotorDuration);
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
        Controls.ActivedSkill = PlayerInput.GetButtonDown ("ActivedSkill");
	}
}
