using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    public Transform m_Target;


    private void Awake()
    {
        if (m_Target == null)
            m_Target = FindObjectOfType<CharacterControlerGames>().transform;

        agent = GetComponent<NavMeshAgent>();
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
