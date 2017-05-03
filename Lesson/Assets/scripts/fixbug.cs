using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;

public class fixbug : MonoBehaviour {
	int kuncilab;
	public GameObject kelastrigger;
	private LoadScene ls;
	public GameObject player;
	public GameObject tut;
	public Text title;

	// Use this for initialization
	void Start () {
		loadPos ();
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

	public void loadPos(){
		if (File.Exists (Application.persistentDataPath + "/posdata.dat")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/posdata.dat", FileMode.Open);

			posData data = (posData)bf.Deserialize (file);
			file.Close ();

			Vector3 temp = player.transform.position;
			temp.x = data.x;
			player.transform.position = temp;
		}
	}

	// Update is called once per frame
	void Update () {
		if (kuncilab == 1) {
			ls.load = "koridor_atas";
			title.text = "Ayo Ujian Sekarang!";
			tut.SetActive (false);
			Time.timeScale = 1;
			Vector3 temp = kelastrigger.transform.position;
			temp.x = 41.9f;
			kelastrigger.transform.position = temp;
		}
		else {
			Debug.Log (kuncilab);
		}
	}
}
