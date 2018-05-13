using UnityEngine;

public class Saver : MonoBehaviour {

    public void SaveDisabledObject(Transform _objectDisabled)
    {
        string id = _objectDisabled.name + _objectDisabled.position.sqrMagnitude;
        if( PlayerPrefs.GetString(id) == "")
            PlayerPrefs.SetString(id.ToString(), "false");
    }

    public bool CheckDisabled(GameObject _objectToCheck, Transform _positionObject = null)
    {
        bool isDestroy = false;
        _positionObject = _positionObject == null ? _objectToCheck.transform : _positionObject;

        string id = _positionObject.name + _positionObject.position.sqrMagnitude;
        if (PlayerPrefs.GetString(id) == "false")
            isDestroy = true;

        return isDestroy;
    }
}
