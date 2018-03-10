using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	void Start() {
		StartCoroutine(Spawning.Instance.StartSpawnEnemy(50));
	}
}
