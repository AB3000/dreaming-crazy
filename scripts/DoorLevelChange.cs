using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevelChange : MonoBehaviour {

	public bool isActivated;
	public static int door;
	public AndroControl player;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<AndroControl> ();
		door = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && isActivated) {
			//Application.LoadLevel ("Level2");
			door++;
		//	Debug.Log ("This is door when A is pressed" + door);
			player.transform.position = new Vector3 (GameObject.Find ("ClassDoor" + door).transform.position.x, GameObject.Find ("ClassDoor" + door).transform.position.y,
				GameObject.Find ("ClassDoor" + door).transform.position.z);

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


	}

