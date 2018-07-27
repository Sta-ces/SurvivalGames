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


    public void KillPlayer()
    {
        Death.Invoke();
    }


    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.GetComponent<Boss>())
        {
            if (!SecondChance.Instance.CheckSkill())
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
        if (!CharacterControler.Instance.DeathPlayer && !GameManager.IsPaused)
        {
            Movement();
            LimitMove();
            Turn();
        } else m_rigidbody.velocity = Vector3.zero;
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
		if (Controls.LookX != 0 || Controls.LookZ != 0)
            m_rigidbody.rotation = Quaternion.LookRotation(new Vector3(Controls.LookX, 0, Controls.LookZ));
		else if( !(GameManager.IsAndroid || GameManager.IsIOS) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) )
            m_rigidbody.transform.LookAt(PositionMouse());
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

    private Vector3 PositionMouse()
    {
        Vector3 vect3Mouse = Vector3.zero;

        Ray mousePosition = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(mousePosition, out hit, Mathf.Infinity, 1 << 10))
            vect3Mouse = new Vector3(hit.point.x, 0, hit.point.z);

        return vect3Mouse;
    }

    private Rigidbody m_rigidbody;
}
