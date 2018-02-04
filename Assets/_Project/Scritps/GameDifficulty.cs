using UnityEngine;

public class GameDifficulty : MonoBehaviour {
    
    [Range(.1f, .5f)]
    public float m_DifficultyProgression = .5f;

    private static float DifficultyProgress;


    public static void DifficultyProgression()
    {
        if (Scoring.Score > 0 && Scoring.Score % 10 == 0)
        {
            if (Spawners.SecondsToSpawn > 1)
                Spawners.SecondsToSpawn -= DifficultyProgress;
            else
                Enemy.agent.speed += DifficultyProgress;
        }
    }


    private void Start()
    {
        DifficultyProgress = m_DifficultyProgression;
        DifficultyProgression();
    }
}
