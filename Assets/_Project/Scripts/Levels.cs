using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {

	public void Retry(string _levelName){
		Display.Instance.SetDisplayGameOver(false);
		Score.Instance.ResetScore();
		CharacterControler.Instance.transform.position = CharacterControler.Instance.GetPlayerSpawner();
		CharacterControler.Instance.gameObject.SetActive(true);
		foreach(GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
			Destroy(enemy);
		Spawning.Instance.SetIsBoss(false);
		StartCoroutine(Spawning.Instance.SpawnRobots(Spawning.Instance.GetNumberRobots()));
	}


	private IEnumerator LoadLevelAsync(string _levelName){
		AsyncOperation async = SceneManager.LoadSceneAsync(_levelName);

		while(!async.isDone){
			yield return null;
		}
	}
}
