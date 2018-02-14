using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour {

    [Range(1f, 10f)]
    public float m_SpeedEnemy = 3.5f;


    public void ResetSpeedEnemy(){
        m_SpeedEnemy = m_baseSpeedEnemy;
    }

    public float GetSpeedEnemy(){
        return m_SpeedEnemy;
    }

    public void SetSpeedEnemy(float _addSpeed){
        m_SpeedEnemy += _addSpeed;
    }

    public void GetSpeedEnemy(int _addSpeed){
        m_SpeedEnemy += _addSpeed;
    }


    private void Awake(){
        m_baseSpeedEnemy = m_SpeedEnemy;
    }

    private void Start()
    {
        if(m_target == null)
            m_target = FindObjectOfType<CharacterControlerGames>().transform;
            if(m_target == null)
                m_target = GameObject.FindGameObjectWithTag("Player").transform;
                if(m_target == null)
                    Debug.LogError("The Target Enemy is not specify");
    }

    private void Update()
    {
        if(m_target != null)
        {
            MovementToTarget();
        }

        GetComponent<NavMeshAgent>().speed = m_SpeedEnemy;
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
    private float m_baseSpeedEnemy;
}
