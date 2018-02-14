using UnityEngine;

public class GameDifficulty : MonoBehaviour {
    
    [Range(.1f, .5f)]
    public float m_DifficultyProgression = .5f;
    [Range(1, 5)]
    public int m_MinSecondsSpawn = 1;
    [Range(1, 5)]
    public int m_MaxSpeedEnemy = 5;


    public static void DifficultyProgression()
    {
       /* if (Scoring.Score > 0 && Scoring.Score % 10 == 0)
        {

            if (Spawners.MaxNumberEnemyPerSpawn < Spawners.SpawnerCount)
                Spawners.MaxNumberEnemyPerSpawn++;
            else
            {
                if (Spawners.SecondsToSpawn > MinSecondsSpawn)
                    Spawners.SecondsToSpawn -= DifficultyProgress;
                else if(Enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().speed <= MaxSpeedEnemy)
                    Enemy.GetComponent<UnityEngine.AI.NavMeshAgent>().speed += DifficultyProgress;
            }
        }

        if (Scoring.Score > 0 && Scoring.Score % 100 == 0)
            Spawners.MaxNumberEnemyPerSpawn++;*/
    }


    private void Start()
    {
        DifficultyProgression();
    }
}
