using UnityEngine;

public class MuteAllSounds : SimpleSingleton<MuteAllSounds> {

	private bool mutes = false;
	public bool Mutes{
		get{ return mutes; }
		set{ mutes = value; }
	}

	public void MuteSounds(){
		AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
		MuteAllSounds.Instance.Mutes = AudioListener.volume == 0 ? true : false;
	}
}
