using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherits from class we were  working on (PhysicsObject)
public class AutoMoveDesk : PhysicsObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		targetVelocity = Vector2.left;//moves to the left
	}
}
