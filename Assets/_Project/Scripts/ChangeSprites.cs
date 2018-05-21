using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ChangeSprites : MonoBehaviour {

    public Sprite On;
    public Sprite Off;
	
	void LateUpdate () {
        if(On != null && Off != null)
            GetComponent<Image>().sprite = (MuteAllSounds.Instance.Mutes) ? Off : On;
	}
}
