using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndromedaControl : MonoBehaviour
{
	private Animator animator;
	private int time;
	private bool isRight;

	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
		time = 0;
		isRight = false;
	}

	// Update is called once per frame
	void Update()
	{
		time++;
		//var vertical = Input.GetAxis("Vertical");
		//var horizontal = Input.GetAxis("Horizontal");
		if (Input.GetKey("up") && isRight == true)
		{
			time = 0;
			animator.SetInteger ("Direction", 2);
			this.gameObject.transform.Translate (Vector3.up * 5.0f);

			animator.SetFloat ("pos", this.gameObject.transform.position.y);
			if (time > 10) {
				this.gameObject.transform.Translate (Vector3.down * 9.8f);
				animator.SetFloat ("pos", this.gameObject.transform.position.y);
				time = 0;
			}

		}

		else if (Input.GetKey("up") && isRight == false)
		{
			animator.SetInteger ("Direction", 3);
			this.gameObject.transform.Translate (Vector3.up * 5.0f);
			animator.SetFloat ("pos", this.gameObject.transform.position.y);
			//isRight = false;
		}

		/*else if (Input.GetKey("down"))
		{
			animator.SetInteger("Direction", 0);
		}*/
		else if (Input.GetKey("right"))
		{
			animator.SetInteger("Direction", 0);
			this.gameObject.transform.Translate (Vector3.right * 0.5f);
			animator.SetFloat ("pos", this.gameObject.transform.position.x);
			isRight = true;
		}
		else if (Input.GetKey("left"))
		{
			animator.SetInteger("Direction", 1);
			this.gameObject.transform.Translate (Vector3.left * 0.5f);
			animator.SetFloat ("pos", this.gameObject.transform.position.x);
			isRight = false;
		}
		/*else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 1);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 3);
		}*/
	}
}
