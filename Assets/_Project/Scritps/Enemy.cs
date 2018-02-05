using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    public Transform m_Target;
    [Range(1f, 10f)]
    public float m_SpeedEnemy = 3.5f;
    
    public static NavMeshAgent agent;


    private void Start()
    {
        if(FindObjectOfType<CharacterControlerGames>() != null)
            m_Target = FindObjectOfType<CharacterControlerGames>().transform;    

        agent = GetComponent<NavMeshAgent>();
        agent.speed = m_SpeedEnemy;
    }

    private void Update()
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
            GetComponent<NavMeshAgent>().SetDestination(m_Target.position);
    }
}
