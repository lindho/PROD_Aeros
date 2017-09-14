using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
public class Player : MonoBehaviour {

	const float maxSpeed = 5f;
	float pythagoras = (Mathf.Pow(velocity.x, 2) + (Mathf.Pow(velocity.y, 2)));
	public float moveSpeedGround = 5f;
	public float moveSpeedWater = 3f;
	Vector2 velocity;

	float accelerationTimeGround = .05f;
	float accelerationTimeWater = .2f;
	float accelerationTimeMud  = .3f;

	float velocityXSmoothing;
	float velocityYSmoothing;

	PlayerController controller;

//	Collider collider;
//  Vector2 moveInput;


	void Start () {
		controller = GetComponent <PlayerController>();
	}

	public void Update(){

		if (controller.collisions.below || controller.collisions.above) {
			velocity.y = 0;
		}

		if (controller.collisions.left || controller.collisions.right) {
			velocity.x = 0;
		}

		if (pythagoras > (Mathf.Pow (maxSpeed, 2))) {
			float magnitude = Mathf.Sqrt (pythagoras);
			float multiplier = maxSpeed / magnitude;
			velocity.x *= multiplier;
			velocity.y *= multiplier;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		float targetVelocityX = input.x * moveSpeedGround;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, accelerationTimeGround); //här kan man updatera accelerationstiden baserat på underlag, water och mud variabler finns
		float targetVelocityY = input.y * moveSpeedGround;
		velocity.y = Mathf.SmoothDamp (velocity.y, targetVelocityY, ref velocityYSmoothing, accelerationTimeGround);

		controller.Move (velocity * Time.deltaTime);
	}
}
