using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler : SimpleSingleton<CharacterControler> {


    public enum e_Player{
        Player1,
        Player2
    }


    public Transform m_PlayerSpawner;
    public e_Player m_Player = e_Player.Player1;
    [Range(1f, 10f)]
    public float m_SpeedCharacter = 5f;


    public bool GetActivePlayer(){ return gameObject.activeSelf; }

    public Vector3 GetPlayerSpawner(){ return m_PlayerSpawner.position; }
    public Player GetPlayerInput(){ return m_playerInput; }
    public float GetSpeedCharacter(){ return m_SpeedCharacter; }


    private void Start(){
        SetInfoPlayer();
    }

	private void Update(){
		OtherInput();
	}

    private void FixedUpdate(){
    	Movement();
    	Turn();
    }


    private void SetInfoPlayer()
    {
        if( m_rigidbody == null ){
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        m_playerInput = ReInput.players.GetPlayer(GetIDPlayer(m_Player));

        if( m_PlayerSpawner == null )
            m_PlayerSpawner.position = new Vector3(0,1,0);
    }

    private int GetIDPlayer(e_Player _player){
        int idPlayer = 0;
        switch(_player){
            case e_Player.Player1:
                idPlayer = 0; break;
            case e_Player.Player2:
                idPlayer = 1; break;
            default:
                idPlayer = 0; break;
        }
        return idPlayer;
    }

    private void Movement()
    {
        Vector3 velocity = m_rigidbody.velocity;

        velocity.z = m_playerInput.GetAxis("MoveZ") * m_SpeedCharacter;
        velocity.x = m_playerInput.GetAxis("MoveX") * m_SpeedCharacter;

        m_rigidbody.velocity = velocity;
    }

    private void Turn()
    {
        Quaternion rotation = m_rigidbody.rotation;

        if (m_playerInput.GetAxis("LookX") != 0 || m_playerInput.GetAxis("LookZ") != 0)
            rotation = Quaternion.LookRotation(new Vector3(m_playerInput.GetAxis("LookX"), 0, m_playerInput.GetAxis("LookZ")));

        m_rigidbody.rotation = rotation;
    }

    private void OtherInput(){
        if( m_playerInput.GetButtonDown("Pause") ){
            Display.Instance.SetDisplayPause();
            Levels.Instance.PauseGame();
        }
    }


    private Player m_playerInput;
    private Rigidbody m_rigidbody;
}
