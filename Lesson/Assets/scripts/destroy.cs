using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class destroy : MonoBehaviour
{
	private scoremanager thescoremanager;

    public GameObject ch;
	private GameScore gm;

    void Start()
    {
		gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameScore>();
        ch = GameObject.Find("character");
		thescoremanager = FindObjectOfType<scoremanager> ();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Check collision name

        Debug.Log("collision name = " + col.gameObject.name);
        if (col.gameObject.name == "monster" )
        {
			gm.nyawa = gm.nyawa  - 5  ;
        }
		if (col.gameObject.tag == "coin") {
			Destroy (col.gameObject);
			gm.points += 1;
		}
		if (col.gameObject.name == "rokok") {
			Destroy (col.gameObject);
			gm.nyawa = gm.nyawa - 50;
		}
    }

	void Update ()
	{
		if (gm.nyawa <= 0) {
			
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}
}