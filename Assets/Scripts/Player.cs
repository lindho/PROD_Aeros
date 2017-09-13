using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
public class Player : MonoBehaviour {
	
	public float moveSpeed = 5f;
	Vector2 velocity;

	PlayerController controller;

//	Collider collider;
//  Vector2 moveInput;


	void Start () {
		controller = GetComponent <PlayerController>();
	}

	public void Update(){
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		velocity.x = input.x * moveSpeed;
		velocity.y = input.y * moveSpeed;
		controller.Move (velocity * Time.deltaTime);
	}
}
