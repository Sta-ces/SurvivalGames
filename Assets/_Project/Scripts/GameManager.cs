using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	void Start() {
		StartCoroutine(Spawning.instance.StartSpawnEnemy(50));
	}
}
