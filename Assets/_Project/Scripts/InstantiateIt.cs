using UnityEngine;

public class InstantiateIt : MonoBehaviour {

	public void CreateObjectOAtPosition(GameObject _object){
        if (_object != null && gameObject != null)
		    Instantiate(_object, transform.position, transform.rotation);
	}

    public void MoveObjectOfAtPosition(GameObject _object)
    {
        if (_object != null && gameObject != null)
            _object.transform.position = gameObject.transform.position;
    }
}
