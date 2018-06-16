using UnityEngine;

public class PlayerPrefParam : MonoBehaviour {

	public void PlayerPrefSuperTiki(bool _superTiki)
    {
        PlayerPrefs.SetString("SuperTikiPower", _superTiki.ToString().ToLower());
    }
}
