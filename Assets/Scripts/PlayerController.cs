using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RaycastController {

	public CollisionInfo collisions;

	[HideInInspector]
	public Vector2 keyInput;

	//Animation player
	private Animator anim;
	private bool playerIsMoving;
	private bool demonIsMoving;
	private Vector2 faceDirection;

	[HideInInspector]
	public bool canMove;

	public override void Start(){
		base.Start ();
		anim = GetComponent<Animator> ();
		canMove = true;
	}

	public void PlayerMove(Vector2 velocity, Vector2 input){
		UpdateRayCastOrigins ();
		collisions.Reset ();
		keyInput = input;
		playerIsMoving = false;

		if (!canMove) {
			input = Vector2.zero;
			return;
		}


		if (velocity.x != 0) {
			HorizontalCollisions (ref velocity);
		}

		if (velocity.y != 0) {
			VerticalCollisions (ref velocity);
		}

		if (input.x > 0.5f || input.x < -0.5f) {
			playerIsMoving = true;
			faceDirection = new Vector2 (input.x, 0f);
		}

		if (input.y > 0.5f || input.y < -0.5f) {
			playerIsMoving = true;
			faceDirection = new Vector2 (0f, input.y);
		}

		anim.SetFloat ("MoveY", input.y);
		anim.SetFloat ("MoveX", input.x);
		anim.SetFloat ("FaceX", faceDirection.x);
		anim.SetFloat ("FaceY", faceDirection.y);
		anim.SetBool ("PlayerIsMoving", playerIsMoving);
		transform.Translate (velocity);
	}

	public void DemonMove(Vector2 velocity, Vector2 input){
		UpdateRayCastOrigins ();
		collisions.Reset ();
		keyInput = input;
		demonIsMoving = false;

		if (velocity.x != 0) {
			HorizontalCollisions (ref velocity);
		}

		if (velocity.y != 0) {
			VerticalCollisions (ref velocity);
		}

		if (input.x > 0.5f || input.x < -0.5f) {
			demonIsMoving = true;
			faceDirection = new Vector2 (input.x, 0f);
		}

		if (input.y > 0.5f || input.y < -0.5f) {
			demonIsMoving = true;
			faceDirection = new Vector2 (0f, input.y);
		}

		anim.SetFloat ("MoveY", input.y);
		anim.SetFloat ("MoveX", input.x);
		anim.SetFloat ("FaceX", faceDirection.x);
		anim.SetFloat ("FaceY", faceDirection.y);
		anim.SetBool ("DemonIsMoving", demonIsMoving);

		transform.Translate (velocity);
	}


	void HorizontalCollisions(ref Vector2 velocity){
		float directionX = Mathf.Sign (velocity.x);
		float rayLength = Mathf.Abs (velocity.x) + skinWidth;

		for (int i = 0; i < horizontalRayCount; i++) {
			Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
			rayOrigin += Vector2.up * (horizontalRaySpacing * i);
			RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);
		
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