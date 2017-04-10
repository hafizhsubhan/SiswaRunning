using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuncikl : MonoBehaviour {
	public GameObject kuncikelas;
	public GameObject ent;
	public GameObject ex;
	public bool pintar;

	// Use this for initialization
	void Start () {
		kuncikelas.SetActive (false);
		pintar = false;
		ent.SetActive (false);
		ex.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (pintar) {
			kuncikelas.SetActive (true);
		}
	}
}
