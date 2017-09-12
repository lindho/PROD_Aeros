using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
[RequireComponent(typeof (Collider))]
public class Player : MonoBehaviour {
	
	public float moveSpeed = 5f;
	PlayerController controller;
	Collider collider;
	[HideInInspector]
	public Vector2 moveInput;


	void Start () {
		controller = GetComponent <PlayerController>();
		collider = GetComponent <Collider> ();
	}

	public void Update(){
		Vector2 moveInput = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 moveVelocity = moveInput.normalized * moveSpeed;
		controller.Move (moveVelocity);
	}
}
