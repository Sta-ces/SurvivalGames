using UnityEngine;

public class Spawners {

    public float GetSecondsSpawning(){
        return SecondsSpawning;
    }

    public void SetSecondsSpawning(float _sec){
        SecondsSpawning = _sec;
    }

    public float AddSecondsSpawning(float _sec){
        return SecondsSpawning += _sec;
    }

    public int GetNumberEnemySpawner(){
        return NumberSpawner;
    }

    public void SetNumberEnemySpawner(int _count){
        NumberSpawner = _count;
    }

    public void AddNumberEnemySpawner(int _count){
        NumberSpawner += _count;
    }

    public int GetCountListSpawner(){
        return CountSpawners;
    }

    public void SetCountListSpawner(int _count){
        CountSpawners = _count;
    }

    public int AddCountListSpawner(int _count){
        return CountSpawners += _count;
    }


    private int CountSpawners = 0;
    private float SecondsSpawning = 0;
    private int NumberSpawner = 0;
}