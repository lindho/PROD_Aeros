using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RaycastController {

	public CollisionInfo collisions;

	[HideInInspector]
	public Vector2 playerInput;

	//Animation
	private Animator anim;
	private bool playerIsMoving;
	private Vector2 lastMove;

	public override void Start(){
		base.Start ();
		anim = GetComponent<Animator> ();
	}

	public void Move(Vector2 velocity){
		Move (velocity, Vector2.zero);
	}

	public void Move(Vector2 velocity, Vector2 input){
		UpdateRayCastOrigins ();
		collisions.Reset ();
		playerInput = input;

		if (velocity.x != 0) {
			HorizontalCollisions (ref velocity);
		}

		if (velocity.y != 0) {
			VerticalCollisions (ref velocity);
		}

//		playerInput = input;
//		playerIsMoving = false;
//
//		if (velocity.y < -5 || velocity.x > 5) {
//			HorizontalCollisions (ref velocity);
//			playerIsMoving = true;
//			lastMove = new Vector2 (velocity.y , 0f);
//			anim.SetFloat ("FaceX", lastMove.x);
//		}
//
//		if (velocity.y < -5 || velocity.y > 5) {
//			VerticalCollisions (ref velocity);
//			playerIsMoving = true;
//			lastMove = new Vector2 (0f, velocity.x);
//			anim.SetFloat ("FaceY", lastMove.y);
//		}
//
//		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
//		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
//		anim.SetBool ("PlayerIsMoving", playerIsMoving);
//		anim.SetFloat ("FaceX", lastMove.x);
//		anim.SetFloat ("FaceY", lastMove.y);

		transform.Translate (velocity);
	}

	void HorizontalCollisions(ref Vector2 velocity){
		float directionX = Mathf.Sign (velocity.x);
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;

		for (int i = 0; i < horizontalRayCount; i++) {
			Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

			Debug.DrawRay (rayOrigin, Vector2.right * directionX * rayLength, Color.red);


			if (hit) {
				velocity.x = (hit.distance - skinWidth) * directionX;
				rayLength = hit.distance;
				print(velocity.x);

				collisions.left = directionX == -1;
				collisions.right = directionX == 1;
			}
		}
	}

	void VerticalCollisions(ref Vector2 velocity){
		float directionY = Mathf.Sign (velocity.y);
		float rayLength = Mathf.Abs (velocity.y) + skinWidth;

		for (int i = 0; i < verticalRayCount; i++) {
			Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
			rayOrigin += Vector2.right * (verticalRaySpacing * i + velocity.x);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

			Debug.DrawRay (rayOrigin, Vector2.up * directionY * rayLength, Color.red);

			if (hit) {
				velocity.y = (hit.distance - skinWidth) * directionY;
				rayLength = hit.distance;

				collisions.below = directionY == -1;
				collisions.above = directionY == 1;
			}
		}
	}

	public struct CollisionInfo{
		public bool above, below;
		public bool left, right;

		public void Reset(){
			above = below = false;
			left = right = false;
		}
	}
}