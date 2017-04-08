 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	public int speed; 
	// Use this for initialization


	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
	}



	void OnCollisionEnter2D(Collision2D col)
	{
		//Check collision name


		if (col.gameObject.tag == "block"){

			speed = speed * -1 ;

		}

		if (col.gameObject.tag == "coin") {
			
		}

	}
}
