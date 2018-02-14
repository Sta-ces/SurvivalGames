using UnityEngine;

public class GameDifficulty : MonoBehaviour {
    
    [Range(.1f, 1f)]
    public float m_DifficultyProgression = .5f;
    [Range(1, 5)]
    public int m_MinSecondsSpawn = 1;
    [Range(1, 5)]
    public int m_MaxSpeedEnemy = 5;

    public float GetDifficultyProgression(){
        return m_DifficultyProgression;
    }

    public int GetMinSecondsSpawn(){
        return m_MinSecondsSpawn;
    }

    public int GetMaxSpeedEnemy(){
        return m_MaxSpeedEnemy;
    }


    public static void DifficultyProgression()
    {
        Spawners spawner = new Spawners();
        Enemy enemy = new Enemy();
        GameDifficulty game = new GameDifficulty();

        if (Scoring.Score > 0 && Scoring.Score % 10 == 0)
        {

            if (spawner.GetMaxNumberEnemy() < spawner.GetSecondsSpawning())
                spawner.SetMaxNumberEnemy(1);
            else
            {
                if (spawner.GetSecondsSpawning() > game.GetMinSecondsSpawn())
                    spawner.SetSecondsSpawning(game.GetDifficultyProgression());
                else if(enemy.GetSpeedEnemy() <= game.GetMaxSpeedEnemy())
                    enemy.SetSpeedEnemy(game.GetDifficultyProgression());
            }
        }

        if (Scoring.Score > 0 && Scoring.Score % 100 == 0)
            spawner.SetMaxNumberEnemy(1);
    }
}
