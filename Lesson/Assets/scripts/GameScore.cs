using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {
	public int points;
	public int nyawa;
	public Text yext;
	public Text health;

	// Use this for initialization
	void Start () {
		nyawa = 100;
		yext.text = "Score :  0" ;
		health.text = "Health : 100";
	}
	
	// Update is called once per frame
	void Update () {
		yext.text = "Score :  " + points;
		health.text = "Health : " + nyawa;
	}
}
