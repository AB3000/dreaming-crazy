using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroControl : MonoBehaviour {

	public float maxSpeed = 11f;
	//bool isRight = true;//checks if facing left or right (flips Andromeda)
	Animator a; //accesses the animator, helps to transition to different states
	bool isRight = true;

	//vars for jumping animation
	public bool isOnGround = false;
	public Transform groundCheck;
	float groundRadius = 2f;//bubble around Andro's feet
	//float groundRadius = 0.2f;//bubble around Andro's feet
	public float jForce = 700f;
	public LayerMask wiGround;

	public bool CanMove;
	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
	}

	//mainly for jumping
	void Update(){
		/*if (!CanMove) {
		//	GetComponent<Rigidbody2D>().velocity = new Vector2(0,GetComponent<Rigidbody2D> ().velocity.y);
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
			//isRight = false; 
			a.Play ("Idle");
			return;
		}*/

		if (isOnGround && Input.GetKeyDown (KeyCode.Space)) {
			a.SetBool ("Ground", false); 
			GetComponent<Rigidbody2D>().AddForce (new Vector2 (0,jForce));
			//a.SetBool ("Ground", false); 

		}
			


	}

	void FixedUpdate () {
		//jumping animations
		isOnGround = Physics2D.OverlapCircle (groundCheck.position,
			groundRadius, wiGround);
		
		a.SetBool ("Ground", isOnGround);
	//	a.SetFloat ("verticalSpeed", GetComponent<Rigidbody2D> ().velocity.y);
		a.SetFloat ("verticalSpeed", GetComponent<Rigidbody2D> ().velocity.y + 100);

		//see how much we move along the X-axis/horizontally
		float move = Input.GetAxis("Horizontal");
		a.SetFloat ("speed", Mathf.Abs(move));//cannot have negative
		GetComponent<Rigidbody2D>().velocity = new Vector2(move *maxSpeed, 
			GetComponent<Rigidbody2D>().velocity.y);

		//flip the character
		if (move > 0 && !isRight) {// was !
			Flip ();
		} else {
			if (move < 0 && isRight) { //was without !
				Flip ();
			}
		}
	}

	void Flip(){
		isRight = !isRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1; //flips image horizontally (was -1)
		transform.localScale = scale;
	}
		
}
