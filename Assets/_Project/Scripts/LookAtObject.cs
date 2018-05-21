using UnityEngine;

public class LookAtObject : MonoBehaviour {

    public Transform ObjectToLookAt;

	void Update () {
        if(ObjectToLookAt != null)
            transform.LookAt(ObjectToLookAt);
	}
}
