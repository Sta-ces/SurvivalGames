using UnityEngine;
using UnityEngine.UI;

public class MuteAllSounds : SimpleSingleton<MuteAllSounds> {

    public Text touchMuteSound;

	private static bool mutes = false;
	public static bool Mutes{
		get{ return mutes; }
		set{ mutes = value; }
	}

	public void MuteSounds(){
		AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
		Mutes = AudioListener.volume == 0;
	}

    private void Update()
    {
        if(touchMuteSound != null)
            touchMuteSound.text = Controls.MuteTouch;
    }
}
