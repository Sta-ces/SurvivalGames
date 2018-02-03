using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    public Transform m_Target;
    [Range(1f, 10f)]
    public float m_SpeedEnemy = 3.5f;


    private void Awake()
    {
        if (m_Target == null)
            m_Target = FindObjectOfType<CharacterControlerGames>().transform;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = m_SpeedEnemy;
    }

    private void FixedUpdate()
    {
        MovementToTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == m_Target.gameObject)
            print("NOM NOM NOM");
    }


    private void MovementToTarget()
    {
        agent.destination = m_Target.position;
    }


    private NavMeshAgent agent;
}
