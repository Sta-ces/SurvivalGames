using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroySound : MonoBehaviour {

	void Start () {
		Destroy(gameObject,GetComponent<AudioSource>().clip.length);
	}
}
