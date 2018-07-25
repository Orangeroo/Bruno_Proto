using UnityEngine;
using System.Collections;

public class BrunoController : MonoBehaviour {
	public float velocity = 8f;
	public float jumpForce = 600f;
    Animator anim;
    bool doubleJump = false;

    // Dash
    public float dashSpeed = 300f;
    bool canDash = true;
	public bool dashing = false;
	public float dashDuration = 0.2f;

	// Ground checking
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;

	void Start () 
	{
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () 
	{
		// Move right forever!
		if(!dashing)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, GetComponent<Rigidbody2D>().velocity.y);
		}
	}

	void Update()
	{
        // Ground check
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("Ground", grounded);

        if (grounded)
        {
            doubleJump = false;
            canDash = true;
        }        
	}

	public void Jump()
	{
		if((grounded || !doubleJump))
		{
			doubleJump = !grounded;
			anim.SetBool("Ground", false);
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
		}
	}

	public void Dash()
	{
		if(canDash && !dashing)
		{
			anim.SetTrigger("Dash");
			StartCoroutine( Boost(dashDuration) );
		}
	}

	IEnumerator Boost(float boostDur) 
	{
		float time = 0f; 
		canDash = false; 
		dashing = true;
		float originalGravity = GetComponent<Rigidbody2D>().gravityScale;

		GetComponent<Rigidbody2D>().gravityScale = 0f; // turn off gravity for awhile
		GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
		while(boostDur > time) 
		{
			time += Time.deltaTime; 
			GetComponent<Rigidbody2D>().velocity = new Vector2(dashSpeed, GetComponent<Rigidbody2D>().velocity.y);
			if( boostDur < time )
			{
				GetComponent<Rigidbody2D>().gravityScale = originalGravity; // turn gravity back on
				dashing = false;
			}
				
			yield return 0;
		}
	}

	public Vector2 GetVelocity()
	{
		return new Vector2(this.velocity, 0);
	}
}
