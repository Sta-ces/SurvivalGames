using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    public GameObject m_PrefabsEnemy;
    public int m_SecondsToSpawning = 3;
    public List<Transform> m_Spawners;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_SecondsToSpawning);
            int random = Random.Range(0, m_Spawners.Count);
            Instantiate(m_PrefabsEnemy, m_Spawners[random].position, m_Spawners[random].rotation);
        }
    }
}
