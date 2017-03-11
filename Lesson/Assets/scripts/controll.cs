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
	public float high;
	public Transform groundcheck;
	public LayerMask whatisGround;
	public float groundcheckRadius;
	bool isGrounded;

	void FixedUpdate()
	{
		isGrounded = Physics2D.OverlapCircle (groundcheck.position, groundcheckRadius, whatisGround);
	}
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
  
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
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
