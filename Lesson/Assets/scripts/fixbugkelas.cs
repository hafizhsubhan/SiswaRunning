using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class fixbugkelas : MonoBehaviour {
	private LoadMateri key;
	// Use this for initialization
	void Start () {
		key = FindObjectOfType<LoadMateri> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (key.x >= 4) {
			Savekunci ();
			Debug.Log ("You Got a Key!");
		}
	}

	public void Savekunci(){ 

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/kuncidata.dat");

		kunci data = new kunci ();
		data.kuncilab = 1;

		bf.Serialize (file, data);
		file.Close ();
	}
}

[System.Serializable]
class kunci {
	public int kuncilab;
}
