using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour {

	public AudioSource bgm;
	public bool passong;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (this);
		AudioSource bgm = GetComponent<AudioSource> ();
	}

	void Update(){
		if (passong){
			if (bgm.isPlaying) {
				bgm.Pause ();
				passong = false;
			} else if (!bgm.isPlaying){
				bgm.Play ();
				Debug.Log ("Play");
				passong = false;
			}
		}
	}
}
