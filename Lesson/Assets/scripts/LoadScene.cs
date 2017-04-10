using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
	public GameObject en;
	public Text coin;
	public Text nyawa;
	public string load;

	public GameObject next;
	public bool inZone;
	private GameScore gm;

	// Use this for initialization
	void Start () {
		gm = FindObjectOfType<GameScore> ();
		next.SetActive (false);
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
			en.SetActive (false);
			Time.timeScale = 0;
			coin.text = ": " + gm.points;
			nyawa.text = ": " + gm.nyawa;
			next.SetActive (true);
		}

	}
}
