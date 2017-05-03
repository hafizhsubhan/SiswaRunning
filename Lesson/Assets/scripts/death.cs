using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class death : MonoBehaviour {
	public GameObject dead;
	public bool mati;
	public bool waktu;
	public Text reason;
	// Use this for initialization
	void Start () {
		dead = GameObject.Find ("GameOver");
		dead.SetActive (false);
		mati = false;
		waktu = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (mati) {
			Time.timeScale = 0;
			if (waktu) {
				reason.text = "Gunakan Wakutmu Sebaik Mungkin!";
			} else if (mati){
				reason.text = "Belajarlah untuk menjadi lebih baik lagi!";
			}
			dead.SetActive (true);
		}
	}
}
