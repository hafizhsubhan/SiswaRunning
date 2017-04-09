using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMateri : MonoBehaviour {
	public GameObject en;
	public bool inZone;
	public string materi;

	// Use this for initialization
	void Start () {
	en = GameObject.Find (materi);
		en.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D triger){
		if (triger.name == "character") {
			inZone = true;
			en.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D trigger){
		if (trigger.name == "character") {
			inZone = false;
			en.SetActive (false);
		}
	}

}
