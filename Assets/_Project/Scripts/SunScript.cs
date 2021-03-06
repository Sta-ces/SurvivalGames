﻿using UnityEngine;

public class SunScript : MonoBehaviour {

	[Range(0.1f,10f)]
	public float SpeedSunRotation = 1f;

	void Update(){
        if(!GameManager.IsPaused)
		    transform.Rotate(0, SpeedSunRotation * Time.deltaTime, 0);
	}
}
