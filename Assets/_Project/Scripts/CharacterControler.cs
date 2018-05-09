using UnityEngine;
using UnityEngine.Events;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler : SimpleSingleton<CharacterControler> {

    public enum e_Player{
        Player1,
        Player2
    }

    public e_Player m_Player = e_Player.Player1;
    [Range(1f, 10f)]
	public float m_SpeedCharacter = 5f;

	[Header("Pause")]
	public UnityEvent Pause;

	[Header("Death")]
	public UnityEvent Death;


	private void OnCollisionEnter(Collision col){
		if( col.gameObject.GetComponent<EnemyControler>() || col.gameObject.GetComponent<Boss>() ){
			Death.Invoke();
		}
	}

	private bool deathPlayer = false;
	public bool DeathPlayer{
		get{ return deathPlayer; }
		set { deathPlayer = value; }
	}

	private Player m_playerInput;
	public Player PlayerInput{
		get{ return m_playerInput; }
		set{ m_playerInput = value; }
	}

	public float SpeedCharacter{
		get{ return m_SpeedCharacter; }
		set{ m_SpeedCharacter = value; }
	}


    private void Start(){
		CharacterControler.Instance.DeathPlayer = false;
        SetInfoPlayer();
    }

	private void Update(){
		if (!CharacterControler.Instance.DeathPlayer) {
			SetControls ();
			OtherInput ();
		}
	}

    private void FixedUpdate(){
		if (!CharacterControler.Instance.DeathPlayer) {
			Movement ();
			Turn ();
		}
    }


    private void SetInfoPlayer()
    {
        if( m_rigidbody == null ){
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

		CharacterControler.Instance.PlayerInput = ReInput.players.GetPlayer(GetIDPlayer(m_Player));
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

	private void SetControls(){
		Controls.MoveX = m_playerInput.GetAxis ("MoveX");
		Controls.MoveZ = m_playerInput.GetAxis ("MoveZ");
		Controls.LookX = m_playerInput.GetAxis ("LookX");
		Controls.LookZ = m_playerInput.GetAxis ("LookZ");
		Controls.Pause = m_playerInput.GetButtonDown ("Pause");
		Controls.Shoot = m_playerInput.GetButtonDown ("Shoot");
		Controls.Reload = m_playerInput.GetButtonDown ("Reload");
	}

    private void Movement()
    {
        Vector3 velocity = m_rigidbody.velocity;

		velocity.z = Controls.MoveZ * SpeedCharacter;
		velocity.x = Controls.MoveX * SpeedCharacter;

        m_rigidbody.velocity = velocity;
    }

    private void Turn()
    {
        Quaternion rotation = m_rigidbody.rotation;

		if (Controls.LookX != 0 || Controls.LookZ != 0)
			rotation = Quaternion.LookRotation(new Vector3(Controls.LookX, 0, Controls.LookZ));

        m_rigidbody.rotation = rotation;
    }

    private void OtherInput(){
		if( Controls.Pause )
            Display.Instance.SetDisplayPause();
    }


    private Rigidbody m_rigidbody;
}
