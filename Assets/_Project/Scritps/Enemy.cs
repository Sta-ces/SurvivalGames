using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    public Transform m_Target;
    [Range(1f, 10f)]
    public float m_SpeedEnemy = 3.5f;
    
    public static NavMeshAgent agent;


    private void Awake()
    {
        if (m_Target == null && FindObjectOfType<CharacterControlerGames>() != null)
            m_Target = FindObjectOfType<CharacterControlerGames>().transform;

        agent = GetComponent<NavMeshAgent>();
        agent.speed = m_SpeedEnemy;
    }

    private void FixedUpdate()
    {
        if(m_Target != null)
        {
            MovementToTarget();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == m_Target.gameObject)
            collision.gameObject.SetActive(false);
    }


    private void MovementToTarget()
    {
        if(m_Target.gameObject.activeSelf)
            agent.destination = m_Target.position;
    }
}
