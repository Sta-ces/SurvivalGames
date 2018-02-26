using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	[Header("Enemy")]
	public GameObject m_PrefabsEnemy;
	public CharacterControlerGames m_CharacterControler;

	[Header("Spawning")]
    [Range(.1f, 20f)]
	public float m_SecondsSpawning = 5f;
    [Range(1, 2)]
    public int m_NumEnemySpawn = 1;

    [Header("List Spawners")]
    public List<Transform> m_ListSpawner;


    public static Spawners SpawnersClass;


    public IEnumerator StartSpawn(){
        while (m_CharacterControler.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(SpawnersClass.GetSecondsSpawning());
            int randomNumberEnemy = Random.Range(1, SpawnersClass.GetNumberEnemySpawner() + 1);
            for(int s = 0; s < randomNumberEnemy; s++)
            {
                int random = Random.Range(0, SpawnersClass.GetCountListSpawner());
                Instantiate(m_PrefabsEnemy, m_ListSpawner[random].position, m_ListSpawner[random].rotation);
            }
        }
    }


    private void Awake(){
    	if( m_CharacterControler == null )
    		m_CharacterControler = FindObjectOfType<CharacterControlerGames>();
            if(m_CharacterControler == null)
                m_CharacterControler = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControlerGames>();
                if(m_CharacterControler == null)
                    Debug.LogError("The Target Enemy is not specify");

        SpawnersClass = new Spawners();
    }

    private void Start()
    {
        SpawnersClass.SetSecondsSpawning(m_SecondsSpawning);
    	SpawnersClass.SetNumberEnemySpawner(m_NumEnemySpawn);
    	SpawnersClass.SetCountListSpawner(m_ListSpawner.Count);

        StartCoroutine("StartSpawn");
    }
}
