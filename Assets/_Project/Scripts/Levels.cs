using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : SimpleSingleton<Levels> {

	public int LevelsAdventure{
		get{ return PlayerPrefs.GetInt ("Levels", 1); }
		set{ PlayerPrefs.SetInt("Levels", value); }
	}

	public void QuitGame(){ Application.Quit(); }

	public void LoadLevel(int _idLevel){ LoadLevel (SceneManager.GetSceneAt (_idLevel).name); }
	public void LoadLevel(string _nameLevel){ SceneManager.LoadScene (_nameLevel); }

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
