using UnityEngine;

public class Enemy {

    public void ResetSpeedEnemy(){
        SpeedEnemy = BaseSpeedEnemy;
    }

    public float GetSpeedEnemy(){
        return SpeedEnemy;
    }

    public void SetSpeedEnemy(float _speed){
        SpeedEnemy = _speed;
    }

    public void SetSpeedEnemy(int _speed){
        SpeedEnemy = _speed;
    }

    public float AddSpeedEnemy(float _speed){
    	return SpeedEnemy += _speed;
    }

    public float GetBaseSpeedEnemy(){
    	return BaseSpeedEnemy;
    }

    public void SetBaseSpeedEnemy(float _speed){
    	BaseSpeedEnemy = _speed;
    	SetSpeedEnemy(_speed);
    }

    public void SetBaseSpeedEnemy(int _speed){
    	BaseSpeedEnemy = _speed;
    	SetSpeedEnemy(_speed);
    }


    private float SpeedEnemy = 0;
    private float BaseSpeedEnemy = 0;
}
