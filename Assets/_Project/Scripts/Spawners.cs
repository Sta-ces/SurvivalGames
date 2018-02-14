using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    public GameObject m_PrefabsEnemy;
    public float m_SecondsToSpawning = 3;
    public List<Transform> m_Spawners;

    public static float SecondsToSpawn;
    public static int MaxNumberEnemyPerSpawn = 2;
    public static int SpawnerCount;


    private void Awake()
    {
        SecondsToSpawn = m_SecondsToSpawning;
        SpawnerCount = m_Spawners.Count;
    }

    private IEnumerator Start()
    {
        CharacterControlerGames character = FindObjectOfType<CharacterControlerGames>();
        while (character != null && character.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(SecondsToSpawn);
            int randomNumberEnemy = Random.Range(1, MaxNumberEnemyPerSpawn);
            for(int s = 0; s < randomNumberEnemy; s++)
            {
                int random = Random.Range(0, SpawnerCount);
                Instantiate(m_PrefabsEnemy, m_Spawners[random].position, m_Spawners[random].rotation);
            }
        }
    }
}
