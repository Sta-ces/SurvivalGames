using UnityEngine;

public class MuteAllSounds : SimpleSingleton<MuteAllSounds> {

	public AudioListener ListenerToMute;

	private bool mutes = false;
	public bool Mutes{
		get{ return mutes; }
		set{ mutes = value; }
	}

	public void MuteSounds(){
		AudioListener audio;

		if(ListenerToMute == null){
			if(GetComponent<AudioListener>())
				audio = GetComponent<AudioListener>();
			else audio = null;
		} else audio = ListenerToMute;

		if(audio != null){
			audio.enabled = !audio.enabled;
			MuteAllSounds.Instance.Mutes = audio.enabled;
		} else Debug.LogError("Audio Listener Miss");
	}
}
