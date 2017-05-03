using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {
	public int points;
	public int nyawa;
	public bool saveScore;
	public Text yext;
	public Text health;

	// Use this for initialization
	void Start () {
		if (File.Exists (Application.persistentDataPath + "/scoredata.dat")) {
			Load ();
		} else {
			points = 0;
			nyawa = 100;
		}
	}
	
	// Update is called once per frame
	void Update () {
		yext.text = "Score :  " + points;
		health.text = "Health : " + nyawa;

		if (saveScore) {
			SaveScore ();
		}
	}

	public void SaveScore(){ //menyimpan skor dan nyawa

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/scoredata.dat");

		ScoreData data = new ScoreData ();
		data.coin = points;
		data.nyawaSis = nyawa;

		bf.Serialize (file, data);
		file.Close ();
	}

	public void Load(){ //
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (Application.persistentDataPath + "/scoredata.dat", FileMode.Open);

		ScoreData data = (ScoreData)bf.Deserialize (file);
		file.Close ();
		points = data.coin;
		nyawa = data.nyawaSis;
	}
}

[System.Serializable]
class ScoreData{
	public int coin;
	public int nyawaSis;
}