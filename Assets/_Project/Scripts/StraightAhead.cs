using UnityEngine;

public class StraightAhead : MonoBehaviour {

    [Range(0, 20)]
    public float Speed = 1;
	
	void Update () {
        transform.localPosition -= (Vector3.forward * Speed);
	}
}
