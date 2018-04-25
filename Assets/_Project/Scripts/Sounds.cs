using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour {

	public AudioClip m_DeathSound;
	public AudioClip m_HitSound;

	public AudioClip GetDeathSound(){ return m_DeathSound; }
	public AudioClip GetHitSound(){ return m_HitSound; }

	public void PlaySounds(AudioClip _clip){
		GetComponent<AudioSource>().clip = _clip;
		GetComponent<AudioSource>().Play();
	}
}
