using UnityEngine;

public class GameDifficulty : MonoBehaviour {
    
    [Range(.1f, .5f)]
    public float m_DifficultyProgression = .5f;


    public void DifficultyProgression()
    {
        if (Scoring.Score > 0 && Scoring.Score % 10 == 0)
        {
            if (Spawners.SecondsToSpawn > 1)
                Spawners.SecondsToSpawn -= m_DifficultyProgression;
            else
                Enemy.agent.speed += m_DifficultyProgression;
        }
    }


    private void Start()
    {
        DifficultyProgression();
    }
}
