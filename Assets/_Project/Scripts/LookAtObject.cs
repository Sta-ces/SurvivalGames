using UnityEngine;

public class LookAtObject : MonoBehaviour {

    public Transform ObjectToLookAt;

	private void LateUpdate() {
        if(ObjectToLookAt != null)
            transform.LookAt(ObjectToLookAt);
	}
}
