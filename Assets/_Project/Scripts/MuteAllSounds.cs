using UnityEngine;

public class MuteAllSounds : SimpleSingleton<MuteAllSounds> {

	private static bool mutes = false;
	public static bool Mutes{
		get{ return mutes; }
		set{ mutes = value; }
	}

	public void MuteSounds(){
		AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
		Mutes = AudioListener.volume == 0;
	}
}
