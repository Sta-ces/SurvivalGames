using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

[RequireComponent(typeof(Rigidbody))]
public class CharacterControlerGames : MonoBehaviour {

    public int m_IDPlayerController = 0;
    [Range(1f, 10f)]
    public float m_SpeedCharacter = 5f;


    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
        m_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        m_player = ReInput.players.GetPlayer(m_IDPlayerController);
    }

    private void Update()
    {
        Vector3 velocity = m_rigidbody.velocity;

        velocity.z = m_player.GetAxis("MoveZ") * m_SpeedCharacter;
        velocity.x = m_player.GetAxis("MoveX") * m_SpeedCharacter;

        m_rigidbody.velocity = velocity;
    }


    private Rigidbody m_rigidbody;
    private Player m_player;
}
