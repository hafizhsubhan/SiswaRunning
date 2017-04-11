using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour {
	public GameObject tutor;
	int x = 1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (x >= 3) {
			Time.timeScale = 1;
			Destroy (tutor = GameObject.Find ("tutor"));
		}	
	}

	public void clos(){
		Destroy(tutor = GameObject.Find ("tutor" + x));
		x += 1;
	}
}
