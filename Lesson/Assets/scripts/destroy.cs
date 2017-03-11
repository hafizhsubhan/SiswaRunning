using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class destroy : MonoBehaviour
{
	private scoremanager thescoremanager;

    public GameObject ch;

    void Start()
    {
        ch = GameObject.Find("character");
		thescoremanager = FindObjectOfType<scoremanager>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name

        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "monster" )
        {
			thescoremanager.scorenaik = false;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		
			thescoremanager.ScoreCount = 0;
			thescoremanager.scorenaik = true;
        }
    }
}