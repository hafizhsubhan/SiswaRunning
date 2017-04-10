using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadMateri : MonoBehaviour {
	public Text jdl;
	public Text mtr;
	public string judul;
	public string materi;
	public GameObject blj;


	// Use this for initialization
	void Start () {
		blj = GameObject.Find ("belajar");
		blj.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D triger){
		if (triger.name == "character") {
			blj.SetActive (true);
			jdl.text = judul;
			mtr.text = materi;
		}
	}
}
