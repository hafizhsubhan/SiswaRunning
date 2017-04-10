using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class fixbug : MonoBehaviour {
	int kuncilab;
	public GameObject kelastrigger;
	private LoadScene ls;



	// Use this for initialization
	void Start () {
		Loadkunci();
		ls = FindObjectOfType<LoadScene> ();
	}

	public void Loadkunci(){
		if (File.Exists (Application.persistentDataPath + "/kuncidata.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/kuncidata.dat", FileMode.Open);

			kunci data = (kunci)bf.Deserialize (file);
			file.Close ();

			kuncilab = data.kuncilab;
		}

	}

	// Update is called once per frame
	void Update () {
		if (kuncilab != 0) {
			ls.load = "koridor_atas";
			Vector3 temp = kelastrigger.transform.position;
			temp.x = 41.9f;
			kelastrigger.transform.position = temp;
		}
	}
}
