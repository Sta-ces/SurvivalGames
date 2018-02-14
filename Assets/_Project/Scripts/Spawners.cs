using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    public GameObject m_PrefabsEnemy;
    public float m_SecondsToSpawning = 3;
    public List<Transform> m_Spawners;
    public int m_MaxNumberEnemyPerSpawn = 2;


    public float GetSecondsSpawning(){
        return m_baseSecondsToSpawning;
    }

    public void SetSecondsSpawning(float _addSeconds){
        m_SecondsToSpawning += _addSeconds;
    }

    public void SetSecondsSpawning(int _addSeconds){
        m_SecondsToSpawning += _addSeconds;
    }

    public void ResetSecondsSpawning(){
        m_SecondsToSpawning = m_baseSecondsToSpawning;
    }

    public int GetMaxNumberEnemy(){
        return m_baseMaxNumberEnemy;
    }

    public void SetMaxNumberEnemy(int _addEnemy){
        m_MaxNumberEnemyPerSpawn += _addEnemy;
    }

    public void ResetMaxNumberEnemy(){
        m_MaxNumberEnemyPerSpawn = m_baseMaxNumberEnemy;
    }


    private void Awake(){
        m_baseSecondsToSpawning = m_SecondsToSpawning;
        m_baseMaxNumberEnemy = m_MaxNumberEnemyPerSpawn;
    }

    private IEnumerator Start()
    {
        CharacterControlerGames character = FindObjectOfType<CharacterControlerGames>();
        while (character != null && character.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(m_SecondsToSpawning);
            int randomNumberEnemy = Random.Range(1, m_MaxNumberEnemyPerSpawn);
            for(int s = 0; s < randomNumberEnemy; s++)
            {
                int random = Random.Range(0, m_Spawners.Count);
                Instantiate(m_PrefabsEnemy, m_Spawners[random].position, m_Spawners[random].rotation);
            }
        }
    }


    private float m_baseSecondsToSpawning;
    private int m_baseMaxNumberEnemy;
}
