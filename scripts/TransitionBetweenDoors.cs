using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBetweenDoors : MonoBehaviour {

	public bool isActivated;
	public static int door;
	public AndroControl player;
	static bool outsideRoom;

	public string inOut; 
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<AndroControl> ();
		door = 1;
		outsideRoom = true;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && isActivated) {
			//Application.LoadLevel ("Level2");
			if (outsideRoom) {
				door++;
			} else {
				door--;
			}
				Debug.Log ("This is door when A is pressed" + door);
			player.transform.position = new Vector3 (GameObject.Find (inOut + door).transform.position.x, GameObject.Find (inOut + door).transform.position.y - 13,
				GameObject.Find (inOut + door).transform.position.z);
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


}