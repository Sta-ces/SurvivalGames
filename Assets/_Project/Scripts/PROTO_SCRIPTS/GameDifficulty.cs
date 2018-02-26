using UnityEngine;

public class GameDifficulty : MonoBehaviour {
    
    [Header("Difficulty Parameters")]
    [Range(.1f, 1f)]
    public float m_DifficultyProgression = .5f;
    [Range(1, 5)]
    public int m_MinSecondsSpawn = 1;
    [Range(1, 5)]
    public int m_MaxSpeedEnemy = 5;


    public static Difficulties DifficultiesClass;


    public static void DifficultyProgression()
    {
        if (Scoring.Score > 0 && Scoring.Score % 10 == 0)
        {

            if (SpawnEnemy.SpawnersClass.GetNumberEnemySpawner() < SpawnEnemy.SpawnersClass.GetCountListSpawner())
                SpawnEnemy.SpawnersClass.AddNumberEnemySpawner(1);
            else
            {
                if (SpawnEnemy.SpawnersClass.GetSecondsSpawning() > GameDifficulty.DifficultiesClass.GetMinSecondsSpawn())
                    SpawnEnemy.SpawnersClass.SetSecondsSpawning(GameDifficulty.DifficultiesClass.GetDifficultyProgression());
                else if(Enemies.EnemyClass.GetSpeedEnemy() <= GameDifficulty.DifficultiesClass.GetMaxSpeedEnemy())
                    Enemies.EnemyClass.AddSpeedEnemy(GameDifficulty.DifficultiesClass.GetDifficultyProgression());
            }
        }

        if (Scoring.Score > 0 && Scoring.Score % 100 == 0)
            SpawnEnemy.SpawnersClass.AddNumberEnemySpawner(1);
    }


    private void Awake(){
        DifficultiesClass = new Difficulties();
    }

    private void Start(){
        DifficultiesClass.SetDifficultyProgression(m_DifficultyProgression);
        DifficultiesClass.SetMinSecondsSpawn(m_MinSecondsSpawn);
        DifficultiesClass.SetMaxSpeedEnemy(m_MaxSpeedEnemy);
    }
}
