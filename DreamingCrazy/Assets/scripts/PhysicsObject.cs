using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {

	public float minGroundNormalY = .65f;
	public float gravityModifier = 1f;

	protected bool grounded;
	protected Vector2 groundNormal;
	protected Rigidbody2D rb2d;

	//other classes will inherit, but not accessible to outside classes 
	protected Vector2 velocity;
	protected ContactFilter2D contactFilter;
	protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
	protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);

	protected const float minMoveDistance = 0.001f;
	protected const float shellRadius = 0.01f;

	void OnEnable(){
		rb2d = GetComponent<Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		contactFilter.useTriggers = false;
		//what layers we should check our collision on
		contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
		contactFilter.useLayerMask = true;

	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		//move our object downward each frame bc of gravity
		velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;

		grounded = false;//player is not grounded

		//determines the next position of the object based on gravity
		Vector2 deltaPosition = velocity * Time.deltaTime; 

		Vector2 move = Vector2.up * deltaPosition.y;//we'll pass this to movement function

		Movement (move, true);

	}

	//moves object based on values calculated, sets position of object's Rigidbody 2d
	void Movement(Vector2 move, bool yMovement){
		float distance = move.magnitude;
		//checks if distance is greater than min value
		if (distance > minMoveDistance) {
			//checks if any of attached colliders overlap with anything in next
			//frame (use Rigidbody2D.cast--cast into the scene)
			//last parameter = shell, makes sure we don't get stuck inside
			//another collider
			int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius); 
			hitBufferList.Clear ();
			for (int i = 0; i < count; i++) {
				hitBufferList.Add (hitBuffer [i]);
				//list of objects that overlap with our physics collider
			}

			//check normal of each
			for(int i = 0; i < hitBufferList.Count; i++){
				Vector2 currentNormal = hitBufferList [i].normal;
				if (currentNormal.y > minGroundNormalY) {
					grounded = true;

					if (yMovement) {
						groundNormal = currentNormal;
						currentNormal.x = 0;
					}
				}

				float projection = Vector2.Dot (velocity, currentNormal);
				if (projection < 0) {
					//cancels out part of velocity stopped by collision
					velocity = velocity - projection * currentNormal;
				}

				float modifiedDistance = hitBufferList [i].distance - shellRadius;
				distance = modifiedDistance < distance ? modifiedDistance : distance;
			}

		}
		rb2d.position = rb2d.position + move.normalized * distance;
	}
}
