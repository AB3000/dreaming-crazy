using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLevelChange : MonoBehaviour {

	public bool isActivated;
	public static int level;
	// Use this for initialization
	void Start () {
		level = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && isActivated) {
			Application.LoadLevel ("Level2");
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

