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

    private ControllerMap JoystickMap;

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
        JoystickMap = PlayerInput.controllers.maps.GetMaps(ControllerType.Joystick, 0)[0];
    }

	private void Update(){
		SetControls();

		if( Controls.Mute )
        	MuteAllSounds.Instance.MuteSounds();
	}

	private void SetControls(){
		Controls.MoveX = PlayerInput.GetAxis("MoveX");
        Controls.MoveXTouch = JoystickMap.GetElementMapsWithAction("MoveX")[0].elementIdentifierName;
		Controls.MoveZ = PlayerInput.GetAxis("MoveZ");
        Controls.MoveZTouch = JoystickMap.GetElementMapsWithAction("MoveZ")[0].elementIdentifierName;
        Controls.LookX = PlayerInput.GetAxis("LookX");
        Controls.LookXTouch = JoystickMap.GetElementMapsWithAction("LookX")[0].elementIdentifierName;
        Controls.LookZ = PlayerInput.GetAxis("LookZ");
        Controls.LookZTouch = JoystickMap.GetElementMapsWithAction("LookZ")[0].elementIdentifierName;
        Controls.Pause = PlayerInput.GetButtonDown("Pause");
        Controls.PauseTouch = JoystickMap.GetElementMapsWithAction("Pause")[0].elementIdentifierName;
        Controls.Shoot = PlayerInput.GetButtonDown("Shoot");
        Controls.ShootTouch = JoystickMap.GetElementMapsWithAction("Shoot")[0].elementIdentifierName;
        Controls.Reload = PlayerInput.GetButtonDown("Reload");
        Controls.ReloadTouch = JoystickMap.GetElementMapsWithAction("Reload")[0].elementIdentifierName;
        Controls.Submit = PlayerInput.GetButtonDown("Submit");
        Controls.SubmitTouch = JoystickMap.GetElementMapsWithAction("Submit")[0].elementIdentifierName;
        Controls.Cancel = PlayerInput.GetButtonDown("Cancel");
        Controls.CancelTouch = JoystickMap.GetElementMapsWithAction("Cancel")[0].elementIdentifierName;
        Controls.Mute = PlayerInput.GetButtonDown("Mute");
        Controls.MuteTouch = JoystickMap.GetElementMapsWithAction("Mute")[0].elementIdentifierName;
        Controls.ActivedSkill = PlayerInput.GetButtonDown("ActivedSkill");
        Controls.ActivedSkillTouch = JoystickMap.GetElementMapsWithAction("ActivedSkill")[0].elementIdentifierName;
        Controls.CoolDown = PlayerInput.GetButtonDown("CoolDown");
        Controls.CoolDownTouch = JoystickMap.GetElementMapsWithAction("CoolDown")[0].elementIdentifierName;
        Controls.Shockwave = PlayerInput.GetButtonDown("Shockwave");
        Controls.ShockwaveTouch = JoystickMap.GetElementMapsWithAction("Shockwave")[0].elementIdentifierName;
        Controls.SuperTiki = PlayerInput.GetButtonDown("SuperTiki");
        Controls.SuperTikiTouch = JoystickMap.GetElementMapsWithAction("SuperTiki")[0].elementIdentifierName;
    }
}
