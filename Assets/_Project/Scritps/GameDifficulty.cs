using UnityEngine;

public class GameDifficulty : MonoBehaviour {
    
    [Range(.1f, .5f)]
    public float m_DifficultyProgression = .5f;
    [Range(1, 5)]
    public int m_MinSecondsSpawn = 1;
    [Range(1, 5)]
    public int m_MaxSpeedEnemy = 5;

    private static float DifficultyProgress;
    private static int MinSecondsSpawn;
    private static int MaxSpeedEnemy;


    public static void DifficultyProgression()
    {
        if (Scoring.Score > 0 && Scoring.Score % 10 == 0)
        {

            if (Spawners.MaxNumberEnemyPerSpawn < Spawners.SpawnerCount)
                Spawners.MaxNumberEnemyPerSpawn++;
            else
            {
                if (Spawners.SecondsToSpawn > MinSecondsSpawn)
                    Spawners.SecondsToSpawn -= DifficultyProgress;
                else if(Enemy.agent.speed <= MaxSpeedEnemy)
                    Enemy.agent.speed += DifficultyProgress;
            }
        }

        if (Scoring.Score > 0 && Scoring.Score % 100 == 0)
            Spawners.MaxNumberEnemyPerSpawn++;
    }


    private void Start()
    {
        DifficultyProgress = m_DifficultyProgression;
        MinSecondsSpawn = m_MinSecondsSpawn;
        MaxSpeedEnemy = m_MaxSpeedEnemy;
        DifficultyProgression();
    }
}
