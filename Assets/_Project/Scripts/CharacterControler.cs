using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler : SimpleSingleton<CharacterControler> {


    [Range(1f, 10f)]
	public float m_SpeedCharacter = 5f;

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

	public float SpeedCharacter{
		get{ return m_SpeedCharacter; }
		set{ m_SpeedCharacter = value; }
	}


    private void Start(){
		CharacterControler.Instance.DeathPlayer = false;

        if( m_rigidbody == null ){
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void FixedUpdate(){
		if (!CharacterControler.Instance.DeathPlayer) {
			Movement ();
			Turn ();
		}
    }

    private void Update(){
		if (!CharacterControler.Instance.DeathPlayer) {
			OtherInput ();
		}
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
