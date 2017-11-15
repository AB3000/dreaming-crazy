using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTillStop : MonoBehaviour {
	private Vector2 input;
	private Vector3 move;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame

	void Update ()
	{
		input = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		if (input != Vector2.zero)
		{
			move = (Vector3) input;
		}
		else
		{
			move = Vector3.Lerp (move, Vector3.zero, 1 * Time.deltaTime);
		}
		transform.Translate (move * 10 * Time.deltaTime);    
	}
}
