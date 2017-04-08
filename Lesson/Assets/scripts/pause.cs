using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {
	public bool paused;
	public GameObject showinpaused;

	// Use this for initialization
	void Start () {
		paused = false;
		Time.timeScale = 1;
		showinpaused = GameObject.Find ("paused");
		showinpaused.SetActive (false);
	}

	void Update () { // untuk menghentikan sementara permainan (pause)
		if(paused || Input.GetKeyDown(KeyCode.Escape))
		{
			if(Time.timeScale == 1) 
			{
				Time.timeScale = 0; // untuk mematikan seluruh proses game (animasi, skrip, dll).
				showPause(); // menampilkan pop up pause (Exit, Restart, Resume)
				paused = false;
			} else if (Time.timeScale == 0){
				Debug.Log ("high");
				paused = false;
				Time.timeScale = 1;
				hidePause(); // menutup pop up pause.
			}
		}
	}



	void showPause() {
		showinpaused.SetActive (true);
	}

	void hidePause() {
		showinpaused.SetActive (false);
	}
}
