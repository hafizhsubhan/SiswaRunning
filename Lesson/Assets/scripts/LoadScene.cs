using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {
	public GameObject en;
	public GameObject next;
	public bool inZone;

	// Use this for initialization
	void Start () {
		next = GameObject.FindGameObjectWithTag ("next");
		next.SetActive (false);
		en = GameObject.Find ("enter");
		en.SetActive (false);
	}

	void OnTriggerEnter2D(Collider2D triger){
		if (triger.name == "character") {
			en.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D trigger){
		if (trigger.name == "character") {
			en.SetActive (false);
		}
	}
	void Update() {
		if (inZone) {
			Time.timeScale = 0;
			next.SetActive (true);
		}

	}
}
