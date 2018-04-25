using UnityEngine;

public class DontDestroyOnload : MonoBehaviour {

	void OnEnable(){
        DontDestroyOnLoad(gameObject);

        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
    }
}
