using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;


public class controll : MonoBehaviour
{
    public Rigidbody2D rb;
	public Camera Mainc;
    public float movespeed;
    public bool moveright;
    public bool moveleft;
    public bool jump;
	public float faceright;
	public float high;

	public bool exit = false;
	float SisPosX, SisPosY;
	public Transform groundcheck;
	public LayerMask whatisGround;
	public float groundcheckRadius;
	bool isGrounded;
	public Animator anim;

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundcheck.position, groundcheckRadius, whatisGround);
	}
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		faceright = rb.transform.localScale.x;
		anim = GetComponent<Animator> ();

		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) {
			Load ();
			Vector3 temp = transform.position; // copy to an auxiliary variable...
			//temp.y = SisPosY;
			//temp.x = SisPosX;
			transform.position = temp; // and save the modified value 
			Debug.Log ("Position Loaded " + SisPosX + " & " + SisPosY);
		}

    }

    void Update()
    {
		//Skrip untuk mengendalikan karakter (siswa)
		if (Input.GetKey(KeyCode.A) || moveleft) //bergerak ke arah kiri
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
			if (faceright > 0) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				faceright = rb.transform.localScale.x; // untuk mengubah hadap siswa (dari kanan ke kiri)
			}
        }
		if (Input.GetKey(KeyCode.D) || moveright) //bergerak ke arah kanan
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
			if (faceright < 0) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				faceright = rb.transform.localScale.x; // untuk mengubah hadap siswa (dari kiri ke kanan)
			}
        }

		if (isGrounded) {
			if (jump || Input.GetKey(KeyCode.W)) // untuk melompat
			{
				rb.velocity = new Vector2 (rb.velocity.x, high);
			}
		}

		if (exit) {
			SisPosX = rb.position.x;
			SisPosY = rb.position.y;

			Save ();
			Debug.Log ("Last Position " + SisPosX + " & " + SisPosY);
		}


		anim.SetFloat ("high", rb.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));
	}

	public void Save(){ 

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerdata.dat");

		PlayerData data = new PlayerData ();
		data.SiswaPosX = SisPosX;
		data.SiswaPosY = SisPosY;

		bf.Serialize (file, data);
		file.Close ();
		Debug.Log (data.SiswaPosX + "&" + data.SiswaPosY);

	}

	public void Load(){

		if (File.Exists (Application.persistentDataPath + "/playerdata.dat")) {

			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerdata.dat", FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close ();

			SisPosX = data.SiswaPosX;
			SisPosY = data.SiswaPosY;

		}
	}
}

[System.Serializable]
class PlayerData{
	public float SiswaPosX;
	public float SiswaPosY;
}