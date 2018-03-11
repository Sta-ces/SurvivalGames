using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour {

	public static void PausedGame(){ Time.timeScale = (Time.timeScale == 1) ? 0 : 1; }

	public void LoadLevelAsync(Object _Level){ LoadLevelAsync(_Level.name); }
	public void LoadLevelAsync(int _idLevel){ LoadLevelAsync(SceneManager.GetSceneAt(_idLevel).name); }
	public void LoadLevelAsync(string _nameLevel){ StartCoroutine(LoadLevelAsynchronous(_nameLevel)); }

	private IEnumerator LoadLevelAsynchronous(string _nameLevel){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nameLevel);

        while (!asyncLoad.isDone)
        {
        	print(asyncLoad.progress);
            yield return null;
        }
	}
}
