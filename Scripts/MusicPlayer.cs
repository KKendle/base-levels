using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	
	static MusicPlayer instance = null;

	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip bossClip;
	public AudioClip endClip;

	private AudioSource music;

	void Start() {
		if (instance != null && instance != this) {
			Destroy(gameObject);
			Debug.Log("Duplicate music player found. Destroying");
		}
		else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();

			Debug.Log("Playing beginning of menu music");
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log("music player loaded level " + level);

		if(level == 1) {
			Debug.Log("Playing general game music");
			music.Stop();
			music.clip = gameClip;
			music.loop = true;
			music.Play();
		}
		if(level == 3 || level == 5 || level == 7 || level == 9 || level == 11 || level == 13) {
			Debug.Log("Continuing general game music");
			music.clip = gameClip;
		}
		if(level == 15) {
			Debug.Log("Switching to boss music");
			music.Stop();
			music.clip = bossClip;
			music.loop = true;
			music.Play();
		}
		if(level == 16 || level == 17) {
			Debug.Log("Switching to menu music");
			music.Stop();
			music.clip = endClip;
			music.loop = true;
			music.Play();
		}
	}
}
