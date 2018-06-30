using UnityEngine;
using UnityEngine.Events;
using Rewired;

public class GamePadInputs : SimpleSingleton<GamePadInputs> {

    [Header("Vibration Gamepad")]
    [Range(0,1)]
    public float MotorSpeed = .5f;
    [Range(0,1)]
    public float MotorDuration = 1f;

    [Header("Check each frame")]
    public UnityEvent OnCheck;


	private Player m_playerInput;
	public Player PlayerInput{
		get{
            return (m_playerInput == null) ? ReInput.players.GetPlayer(0) : m_playerInput;
        }
		set{ m_playerInput = value; }
	}

    private ControllerMap mappingController;
    public ControllerMap MappingController
    {
        get
        {
            if (PlayerInput.controllers.maps.GetMaps(ControllerType.Joystick, 0).Count > 0 && IsGamepad)
                mappingController = PlayerInput.controllers.maps.GetMaps(ControllerType.Joystick, 0)[0];
            else if (PlayerInput.controllers.maps.GetMaps(ControllerType.Keyboard, 0).Count > 0 && !IsGamepad)
                mappingController = PlayerInput.controllers.maps.GetMaps(ControllerType.Keyboard, 0)[0];
            else mappingController = null;
            return mappingController;
        }
    }

    public bool IsGamepad
    {
        get
        {
            bool _isGamepad = false;
            if (PlayerInput.controllers.GetLastActiveController() != null)
                _isGamepad = PlayerInput.controllers.GetLastActiveController().type == ControllerType.Joystick;
            return _isGamepad;
        }
    }


    public void VibrationGamepad()
    {
        if(IsGamepad)
            PlayerInput.SetVibration(0, MotorSpeed, MotorDuration);
    }

    

	private void Update(){
        SetControls();

		if( Controls.Mute )
        	MuteAllSounds.Instance.MuteSounds();

        OnCheck.Invoke();
	}
    
	public void SetControls()
    {
        if (PlayerInput != null)
        {
            if (!IsGamepad)
            {
                if (PlayerInput.GetButton("MoveX")) Controls.MoveX = 1;
                else if (PlayerInput.GetNegativeButton("MoveX")) Controls.MoveX = -1;
                else Controls.MoveX = 0;
            }
            else Controls.MoveX = PlayerInput.GetAxis("MoveX");
            if (!IsGamepad)
            {
                if (PlayerInput.GetButton("MoveZ")) Controls.MoveZ = 1;
                else if (PlayerInput.GetNegativeButton("MoveZ")) Controls.MoveZ = -1;
                else Controls.MoveZ = 0;
            }
            else Controls.MoveZ = PlayerInput.GetAxis("MoveZ");
            if (IsGamepad)
            {
                Controls.LookX = PlayerInput.GetAxis("LookX");
                Controls.LookZ = PlayerInput.GetAxis("LookZ");
            }
            Controls.Pause = PlayerInput.GetButtonDown("Pause");
            Controls.Shoot = PlayerInput.GetButtonDown("Shoot");
            Controls.Reload = PlayerInput.GetButtonDown("Reload");
            Controls.Submit = PlayerInput.GetButtonDown("Submit");
            Controls.Cancel = PlayerInput.GetButtonDown("Cancel");
            Controls.Mute = PlayerInput.GetButtonDown("Mute");
            Controls.ActivedSkill = PlayerInput.GetButtonDown("ActivedSkill");
            Controls.CoolDown = PlayerInput.GetButtonDown("CoolDown");
            Controls.Shockwave = PlayerInput.GetButtonDown("Shockwave");
            Controls.SuperTiki = PlayerInput.GetButtonDown("SuperTiki");
        }

        if (MappingController != null)
        {
            Controls.MoveXTouch = CheckJoystick("MoveX");
            Controls.MoveZTouch = CheckJoystick("MoveZ");
            Controls.LookXTouch = CheckJoystick("LookX");
            Controls.LookZTouch = CheckJoystick("LookZ");
            Controls.PauseTouch = CheckJoystick("Pause");
            Controls.ShootTouch = CheckJoystick("Shoot");
            Controls.ReloadTouch = CheckJoystick("Reload");
            Controls.SubmitTouch = CheckJoystick("Submit");
            Controls.CancelTouch = CheckJoystick("Cancel");
            Controls.MuteTouch = CheckJoystick("Mute");
            Controls.ActivedSkillTouch = CheckJoystick("ActivedSkill");
            Controls.CoolDownTouch = CheckJoystick("CoolDown");
            Controls.ShockwaveTouch = CheckJoystick("Shockwave");
            Controls.SuperTikiTouch = CheckJoystick("SuperTiki");
        }
    }

    private string CheckJoystick(string _nameControl)
    {
        string returnValue = "";
        ActionElementMap[] actionElements = MappingController.GetElementMapsWithAction(_nameControl);
        if (actionElements.Length > 0)
        {
            if(actionElements[0] != null)
                returnValue = actionElements[0].elementIdentifierName;
        }
        return returnValue;
    }
}
