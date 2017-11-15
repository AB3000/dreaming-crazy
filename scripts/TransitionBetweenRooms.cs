using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenRooms : MonoBehaviour {

	public bool isActivated;
	public int door;
	public AndroControl player;
	static bool outsideRoom;

	public string inOut; 
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<AndroControl> ();
		door = 0;
		outsideRoom = true;
	}

	// Update is called once per frame
	void Update () {
		if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && isActivated) {
			//Application.LoadLevel ("Level2");
			if (outsideRoom) {
				door++;
				player.isOnGround = true;
				player.transform.position = new Vector3 (GameObject.Find (inOut + door).transform.position.x + 25, GameObject.Find (inOut + door).transform.position.y - 20,
					GameObject.Find (inOut + door).transform.position.z);
			} else {
				door--;
				player.isOnGround = true;
				player.transform.position = new Vector3 (GameObject.Find (inOut + door).transform.position.x - 25, GameObject.Find (inOut + door).transform.position.y - 20,
					GameObject.Find (inOut + door).transform.position.z);
			}
			Debug.Log ("This is door when A is pressed" + door);
			/*player.transform.position = new Vector3 (GameObject.Find (inOut + door).transform.position.x + 25, GameObject.Find (inOut + door).transform.position.y - 20,
				GameObject.Find (inOut + door).transform.position.z);*/
			outsideRoom = !outsideRoom;
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Andromeda") {
			isActivated = true;
		}

		//if (destroyWhenActivated) {
		//Destroy (gameObject); 
		//}

	}

	void OnTriggerExit2D(Collider2D other){
		isActivated = false;
	}

	/*public bool isActivated;
	public static int side;
	public AndroControl player;
	static bool isRight;
	 
	int errorAmount;

	public string scene; *
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<AndroControl> ();
		side = 0;
		isRight = true;
		errorAmount = 20;
	}

	// Update is called once per frame
	void Update () {
		if (isActivated) {

			Debug.Log ("side is now " + side);
			Debug.Log ("isRight is " + isRight + ", and your x offset is " + errorAmount);
			//Application.LoadLevel ("Level2");
			if (isRight && Input.GetKeyDown (KeyCode.RightArrow)) {
				//if (isRight) {
				Debug.Log("You are now in the IF statement.");
				side = 1;
				player.transform.position = new Vector3 (GameObject.Find (scene + side).transform.position.x + errorAmount, 
					GameObject.Find (scene + side).transform.position.y,
					GameObject.Find (scene + side).transform.position.z);
				errorAmount *= -1;
				//isRight = !isRight;

			} else if (!isRight && Input.GetKeyDown (KeyCode.LeftArrow)) {
				Debug.Log("You are now in the ELSE statement.");
				side = 0;
				player.transform.position = new Vector3 (GameObject.Find (scene + side).transform.position.x + errorAmount, 
					GameObject.Find (scene + side).transform.position.y,
					GameObject.Find (scene + side).transform.position.z);
				errorAmount *= -1;
				//isRight = !isRight;
			} 
			isRight = !isRight;
				


			/*player.transform.position = new Vector3 (GameObject.Find (scene + side).transform.position.x + errorAmount, 
				GameObject.Find (scene + side).transform.position.y,
				GameObject.Find (scene + side).transform.position.z);*/
		
		/*}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.name == "Andromeda") {
			isActivated = true;
		}

	}

	void OnTriggerExit2D(Collider2D other){
		isActivated = false;
	}*/


}