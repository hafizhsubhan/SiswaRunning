 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoremanager : MonoBehaviour {

	public Text ScoreText;
	public Text hiScoreText;

	public float ScoreCount;
	public float hiScoreCount;

	private highscore thehighscore;

	public float pointPerSecond;

	public bool scorenaik;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (scorenaik) {
			ScoreCount += pointPerSecond * Time.deltaTime;
		}
	if (hiScoreCount < ScoreCount) {
			
			hiScoreCount = ScoreCount;

		}

	

		ScoreText.text = "Score: " + Mathf.Round(ScoreCount);
		hiScoreText.text = "HighScore: " + Mathf.Round(hiScoreCount);

	}
}
