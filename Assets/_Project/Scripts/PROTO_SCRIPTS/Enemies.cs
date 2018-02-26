using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemies : MonoBehaviour {

    [Header("Speed Enemies")]
    [Range(1f, 10f)]
    public float m_SpeedEnemy = 3.5f;
    

    public static Enemy EnemyClass;


    private void Awake(){
        if(m_target == null)
            m_target = FindObjectOfType<CharacterControlerGames>().transform;
            if(m_target == null)
                m_target = GameObject.FindGameObjectWithTag("Player").transform;
                if(m_target == null)
                    Debug.LogError("The Target Enemy is not specify");

        EnemyClass = new Enemy();
    }

    private void Start()
    {
        EnemyClass.SetBaseSpeedEnemy(m_SpeedEnemy);
    }

    private void Update()
    {
        if(m_target != null)
            MovementToTarget();

        GetComponent<NavMeshAgent>().speed = EnemyClass.GetSpeedEnemy();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == m_target.gameObject)
            collision.gameObject.SetActive(false);
    }


    private void MovementToTarget()
    {
        if(m_target.gameObject.activeSelf)
            GetComponent<NavMeshAgent>().SetDestination(m_target.position);
    }


    private Transform m_target;
}
