using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class time : MonoBehaviour {
	public Text masuk;
	float waktu = 0;

	private death rip;

	// Use this for initialization
	void Start () {
		rip = FindObjectOfType<death> ();
	}
	
	// Update is called once per frame
	void Update () {
		waktu += Time.deltaTime;
		masuk.text = "06:" + Mathf.Round(waktu);
		if (waktu > 15) {
			rip.mati = true;
			rip.waktu = true;
		}

		
	}
}
