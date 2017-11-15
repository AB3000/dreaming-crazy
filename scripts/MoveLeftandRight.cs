using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftandRight : MonoBehaviour {

	private int time;
	private Vector3 scale;
	bool isRight;
	public float moveAmount;
	private float originalAmount;


	// Use this for initialization
	void Start () {
		time = 0;
		scale = transform.localScale;
		isRight = true;
		originalAmount = moveAmount;
		//moveAmount = 20;


	}
	
	// Update is called once per frame
	void Update () {

		if (isRight) {
			this.transform.position = new Vector3 (transform.position.x + moveAmount, transform.position.y,
				transform.position.z);
		} else {
			this.transform.position = new Vector3 (transform.position.x - moveAmount, transform.position.y,
				transform.position.z);
		}

		moveAmount -= moveAmount/4 * Time.deltaTime;
		time++;

		if (time > 5) {
			scale.x *= -1;
			transform.localScale = scale;
			time = 0;
			moveAmount = originalAmount;
			isRight = !isRight;
			StartCoroutine (PauseCharacter ()); 

		}

	}


	IEnumerator PauseCharacter() {
		yield return new WaitForSecondsRealtime(10000);

	}

}
