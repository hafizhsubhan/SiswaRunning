using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class controll : MonoBehaviour
{
    public Rigidbody2D rb;
	public Camera Mainc;
    public float movespeed;
    public bool moveright;
    public bool moveleft;
    public bool jump;
	public float pos;
	public float faceright;
	public float high;
	private GameScore gm;
	public GameObject tutorial;

	public bool exit = false;
	int scene, coin, health;
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
		
		gm = FindObjectOfType<GameScore> ();
        rb = GetComponent<Rigidbody2D>();
		faceright = rb.transform.localScale.x;
		anim = GetComponent<Animator> ();
		tutorial = GameObject.Find ("tutor");
		tutorial.SetActive (false);
		scene = SceneManager.GetActiveScene ().buildIndex;
		tutor ();
    }

	void tutor(){
		Time.timeScale = 0;
		tutorial.SetActive (true);
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


		anim.SetFloat ("high", rb.velocity.y);
		anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));
	}
}
