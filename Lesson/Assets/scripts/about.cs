using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class about : MonoBehaviour {
	GameObject begee;

	public void back(){
		SceneManager.LoadScene ("menu");
	}

	public void reset() {
		File.Delete (Application.persistentDataPath + "/scoredata.dat");
		File.Delete (Application.persistentDataPath + "/scenedata.dat");
		File.Delete (Application.persistentDataPath + "/kuncidata.dat");
		File.Delete (Application.persistentDataPath + "/posdata.dat");
		Destroy (begee = GameObject.Find ("bgm"));
		SceneManager.LoadScene ("menu");
	}
}
