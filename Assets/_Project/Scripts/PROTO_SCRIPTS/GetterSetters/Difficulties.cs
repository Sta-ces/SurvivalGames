using UnityEngine;

public class Difficulties {

    public float GetDifficultyProgression(){
        return DifficultyProgression;
    }

    public void SetDifficultyProgression(float _progression){
    	DifficultyProgression = _progression;
    }

    public void SetDifficultyProgression(int _progression){
    	DifficultyProgression = _progression;
    }

    public void AddDifficultyProgression(float _progression){
    	DifficultyProgression += _progression;
    }

    public int GetMinSecondsSpawn(){
        return MinSecondsSpawn;
    }

    public void SetMinSecondsSpawn(int _minSec){
    	MinSecondsSpawn = _minSec;
    }

    public int GetMaxSpeedEnemy(){
        return MaxSpeedEnemy;
    }

    public void SetMaxSpeedEnemy(int _maxSpeed){
    	MaxSpeedEnemy = _maxSpeed;
    }


    private float DifficultyProgression = 0;
    private int MinSecondsSpawn = 0;
    private int MaxSpeedEnemy = 0;
}
