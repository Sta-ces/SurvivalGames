using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControlerGames : MonoBehaviour {

    public int m_IDPlayerController = 0;
    [Range(1f, 10f)]
    public float m_SpeedCharacter = 5f;
    
    public static Player PlayerInput;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        PlayerInput = ReInput.players.GetPlayer(m_IDPlayerController);
    }

    private void FixedUpdate()
    {
        Movement();
        Turn();
    }


    private void Movement()
    {
        Vector3 velocity = m_rigidbody.velocity;

        velocity.z = PlayerInput.GetAxis("MoveZ") * m_SpeedCharacter;
        velocity.x = PlayerInput.GetAxis("MoveX") * m_SpeedCharacter;

        m_rigidbody.velocity = velocity;
    }

    private void Turn()
    {
        Quaternion rotation = m_rigidbody.rotation;

        if (PlayerInput.GetAxis("LookX") != 0 || PlayerInput.GetAxis("LookZ") != 0)
            rotation = Quaternion.LookRotation(new Vector3(PlayerInput.GetAxis("LookX"), 0, PlayerInput.GetAxis("LookZ")));

        m_rigidbody.rotation = rotation;

    }


    private Rigidbody m_rigidbody;
}
