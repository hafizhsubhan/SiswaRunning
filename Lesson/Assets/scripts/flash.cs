using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class flash : MonoBehaviour {

	public Animator kilau;
	public bool grab;

	// Use this for initialization
	void Start () {
		kilau = GetComponent<Animator> ();
		grab = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (grab) {
			kilau.SetBool ("grab", true);
			grab = false;
		} else {
			kilau.SetBool ("grab", false);
		}
	}
}
