using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawners : MonoBehaviour {

    public GameObject m_PrefabsEnemy;
    public float m_SecondsToSpawning = 3;
    [Range(.1f,.5f)]
    public float m_DifficultyProgression = .5f;
    public List<Transform> m_Spawners;


    private IEnumerator Start()
    {
        while (CharacterControlerGames.PlayerCharacter.activeSelf)
        {
            if (Scoring.Score > 0 && Scoring.Score % 10 == 0 && m_SecondsToSpawning > 1)
                m_SecondsToSpawning -= m_DifficultyProgression;

            yield return new WaitForSeconds(m_SecondsToSpawning);
            int random = Random.Range(0, m_Spawners.Count);
            Instantiate(m_PrefabsEnemy, m_Spawners[random].position, m_Spawners[random].rotation);
        }
    }
}
