using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class controll : MonoBehaviour
{
    public Rigidbody2D rb;
    public float movespeed;
    public bool moveright;
    public bool moveleft;
    public bool jump;
	public float faceright;
	public float high;
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
    }

    void Update()
    {
  
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
			if (faceright > 0) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				faceright = rb.transform.localScale.x;
			}
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
			if (faceright < 0) {
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
				faceright = rb.transform.localScale.x;
			}
        }

        if (moveright)
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        }
        if (moveleft)
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        }



		if (isGrounded) {
			if (jump || Input.GetKey(KeyCode.W))
			{
				rb.velocity = new Vector2 (rb.velocity.x, high);
			}
		}

		anim.SetFloat ("Speed", Mathf.Abs (rb.velocity.x));
    }
}
/* public class touchcontroll : MonoBehaviour {

// Use this for initialization
void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}*/
