using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class destroy : MonoBehaviour
{
	//private scoremanager thescoremanager;

    public GameObject ch;
	public string js;
	private GameScore gm;
	private int nyawa1;
	private LoadMateri lm;
	private death rip;
	private flash cus;

    void Start()
    {
		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameScore>();
		lm = FindObjectOfType<LoadMateri> ();
        ch = GameObject.Find("character");
		rip = FindObjectOfType<death> ();
		cus = FindObjectOfType<flash> ();


		//thescoremanager = FindObjectOfType<scoremanager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name

        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.tag == "monster" )
        {
			gm.nyawa = gm.nyawa  - 5  ;
			}

		if (col.gameObject.tag == "coin") {
			Destroy (col.gameObject);
			gm.points += 1;
		}

		if (col.gameObject.tag == "rokok") {
			cus.grab = true;
			Destroy (col.gameObject);
			gm.nyawa = gm.nyawa - 30 ;
		}

		if (col.gameObject.name == "a" & SceneManager.GetActiveScene().buildIndex == 7) {

			SceneManager.LoadScene ("quiz2");

		}

		if (col.gameObject.name == "b") {



		}

		if (col.gameObject.name == "c") {



		}

		if (col.gameObject.name == "a") {



		}

		if (col.gameObject.name == "b"  & SceneManager.GetActiveScene().buildIndex == 8) {

			SceneManager.LoadScene ("quiz3");

		}

		if (col.gameObject.name == "c") {



		}
		if (col.gameObject.name == "a") {



		}

		if (col.gameObject.name == "b" ) {



		}

		if (col.gameObject.name == "c"  & SceneManager.GetActiveScene().buildIndex == 9) {


			SceneManager.LoadScene ("congrat");
		}
    }

	void Update() {
		if (gm.nyawa <= 0) {
			rip.mati = true;
			rip.waktu = false;
		}
	}
}