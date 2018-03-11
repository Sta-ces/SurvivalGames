using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingLevels : MonoBehaviour {

    public void Restart(){ LoadLevel(SceneManager.GetActiveScene().buildIndex); }
    
    public void LoadLevel(Object _level){ LoadLevel(_level.name); }
    public void LoadLevel(string _nameLevel){ LoadLevel(SceneManager.GetSceneByName(_nameLevel).buildIndex); }
    public void LoadLevel(int _idLevel){ LevelLoader(_idLevel); }
    public static void LevelLoader(int _idLevel){
    	if( _idLevel != -1 )
    		SceneManager.LoadScene(_idLevel);
    	else Debug.LogError("Level can't be loaded !");
    }

    public void AsyncLoadLevel(Object _level){ AsyncLoadLevel(_level.name); }
    public void AsyncLoadLevel(string _nameLevel){ AsyncLoadLevel(SceneManager.GetSceneByName(_nameLevel).buildIndex); }
    public void AsyncLoadLevel(int _idLevel){ StartCoroutine(LoadYourAsyncScene(_idLevel)); }
    IEnumerator LoadYourAsyncScene(int _idLevel)
    {
    	if( _idLevel != -1 ){
	        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_idLevel);

	        while (!asyncLoad.isDone)
	        {
	        	print(asyncLoad.progress);
	            yield return null;
	        }
        } else Debug.LogError("Level can't be loaded !");
    }

    public void QuitApplication(){ ApplicationQuit(); }
    public static void ApplicationQuit(){ Application.Quit(); }

    public void Resume(){ PausedGame(); }
    public static void PausedGame(){ Time.timeScale = (Time.timeScale == 1) ? 0 : 1; }
}
