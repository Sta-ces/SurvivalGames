using UnityEngine;

public class InstantiateIt : MonoBehaviour {

	public void CreateObjectOAtPosition(GameObject _object){
		Instantiate(_object, transform.position, transform.rotation);
	}
}
