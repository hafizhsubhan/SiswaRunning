using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixbug : MonoBehaviour {
	public bool kuncilab = false;
	public GameObject kelastrigger;
	public GameObject koridortrigger;


	// Use this for initialization
	void Start () {
		koridortrigger.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (kuncilab) {
			Destroy (kelastrigger);
			koridortrigger.SetActive (true);
		}
	}
}
