using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour {

    public int NameOfSceneToLoad = 0;
    
	IEnumerator Start () {
		if( NameOfSceneToLoad != 0)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(NameOfSceneToLoad);

            while (!async.isDone)
                yield return null;
        }
	}
}
