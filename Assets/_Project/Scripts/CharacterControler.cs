using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler : SimpleSingleton<CharacterControler> {


    [Range(1f, 10f)]
	public float m_SpeedCharacter = 5f;

    [Header("Limit Zone")]
    public LimitZone LimitsZone;
    [Serializable]
    public struct LimitZone
    {
        public float Top;
        public float Left;
        public float Right;
        public float Bottom;
    }

    [Header("Death")]
	public UnityEvent Death;

    
	private bool deathPlayer = false;
	public bool DeathPlayer{
		get{ return deathPlayer; }
		set { deathPlayer = value; }
	}

	public float SpeedCharacter{
		get{ return m_SpeedCharacter; }
		set{ m_SpeedCharacter = value; }
	}


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.GetComponent<EnemyControler>() || col.gameObject.GetComponent<Boss>())
        {
            if(!SecondChance.Instance.CheckSkill())
                Death.Invoke();
        }
    }

    private void Start(){
		CharacterControler.Instance.DeathPlayer = false;

        if( m_rigidbody == null ){
            m_rigidbody = GetComponent<Rigidbody>();
            m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void FixedUpdate(){
        if (!CharacterControler.Instance.DeathPlayer)
        {
            Movement();
            LimitMove();
            Turn();
        } else m_rigidbody.velocity = Vector3.zero;
    }

    private void Update(){
		if (GameManager.OnPlay && !CharacterControler.Instance.DeathPlayer) {
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

    private void LimitMove()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, LimitsZone.Left, LimitsZone.Right);
        pos.z = Mathf.Clamp(pos.z, LimitsZone.Bottom, LimitsZone.Top);
        transform.position = pos;
    }

    private void Turn()
    {
        Quaternion rotation = m_rigidbody.rotation;

		if (Controls.LookX != 0 || Controls.LookZ != 0)
			rotation = Quaternion.LookRotation(new Vector3(Controls.LookX, 0, Controls.LookZ));
		else if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
			rotation.eulerAngles = TurnFollowMouse();

        m_rigidbody.rotation = rotation;
    }

    private Vector3 TurnFollowMouse()
    {
    	//Grab the current mouse position on the screen
    	Vector3 mousePos = Input.mousePosition;
    	Vector3 vect3Mouse = new Vector3(mousePos.x,mousePos.y, mousePos.z - Camera.main.transform.position.z);
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(vect3Mouse);
		//Rotates toward the mouse
		float angle = Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x))*Mathf.Rad2Deg - 90;
        return new Vector3(0, -angle ,0);
    }

    private void OtherInput(){
		if( Controls.Pause )
            Display.Instance.SetDisplayPause();
    }

    private Rigidbody m_rigidbody;
}
