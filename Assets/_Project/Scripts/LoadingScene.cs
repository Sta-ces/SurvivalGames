using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    public string NameOfSceneToLoad;
    
	IEnumerator Start () {
		if( NameOfSceneToLoad != "")
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(NameOfSceneToLoad);

            while (!async.isDone)
                yield return null;
        }
	}
}
