using UnityEngine;

public class Calcul
{
	public static float ValueToPercentage(float _num, float _maxNum, float _minNum = 0){
        return ((_num - _minNum) * 100) / (_maxNum - _minNum);
    }

    public static float PercentageToValue(float _value, float _maxNum, float _minNum = 0){
    	return (_value * (_maxNum - _minNum) / 100) + _minNum;
    }

    public static float RandomNumber()
    {
        return Random.Range(0, 2);
    }

    public static float RandomNumber(float _min, float _max)
    {
        return Random.Range(_min, _max);
    }

    public static int RandomNumber(int _min, int _max){
    	return Random.Range(_min, _max);
    }

    public static float TileMapPosition(float _sizeTile, float _positionTile)
    {
        return -_sizeTile / 2 + 0.5f + _positionTile;
    }
}
