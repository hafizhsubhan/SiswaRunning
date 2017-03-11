using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class highscore : MonoBehaviour {

	//public Text hiScoreText;
	public Text hiScoreText;
	public float hiScoreCount;
	private scoremanager scoreskrg;
	public float a;



	// Use this for initialization
	void Start () {
		scoreskrg = new scoremanager ();
		a = scoreskrg.ScoreCount;
	
	}

	// Update is called once per frame
	void Update () {
		
		if (scoreskrg.ScoreCount > hiScoreCount) {

			hiScoreCount = scoreskrg.ScoreCount ;

		}

		hiScoreText.text = "HighScore: " + Mathf.Round(a);

		
	}
}
