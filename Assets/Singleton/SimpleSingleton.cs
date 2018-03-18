using UnityEngine;

public class SimpleSingleton<T> : MonoBehaviour where T : MonoBehaviour {

	private static T instance;
	public static T Instance{
		get{
			if (instance == null) {
				instance = GameObject.FindObjectOfType<T> ();

				if (instance == null) {
					GameObject container = new GameObject (typeof(T).ToString());
					instance = container.AddComponent<T> ();
				}
			}

			return instance;
		}
	}
}
