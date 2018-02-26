using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControler : MonoBehaviour {

	public static CharacterControler instance;

	public int m_IDPlayerController = 0;
    [Range(1f, 10f)]
    public float m_SpeedCharacter = 5f;


    public float GetSpeedCharacter(){
    	return m_SpeedCharacter;
    }


	private void Awake()
    {
    	if( instance != null ){
    		Destroy(instance);
    		return;
    	}

    	instance = this;


        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        m_playerInput = ReInput.players.GetPlayer(m_IDPlayerController);
    }

    private void FixedUpdate(){
    	Movement();
    	Turn();
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


    private Player m_playerInput;
    private Rigidbody m_rigidbody;
}
