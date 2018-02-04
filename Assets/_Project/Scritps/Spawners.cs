using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    public GameObject m_PrefabsEnemy;
    public float m_SecondsToSpawning = 3;
    public List<Transform> m_Spawners;

    public static float SecondsToSpawn;


    private void Awake()
    {
        SecondsToSpawn = m_SecondsToSpawning;
    }

    private IEnumerator Start()
    {
        while (FindObjectOfType<CharacterControlerGames>().gameObject.activeSelf)
        {
            yield return new WaitForSeconds(SecondsToSpawn);
            int random = Random.Range(0, m_Spawners.Count);
            Instantiate(m_PrefabsEnemy, m_Spawners[random].position, m_Spawners[random].rotation);
        }
    }
}
