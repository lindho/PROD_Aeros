using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (PlayerController))]
public class Player : MonoBehaviour {

	PlayerController controller;

	public LayerMask groundLayer;

	private Vector2 velocity;

	public float damage = 3;


	public float moveSpeedGround = 5f;
//	public float moveSpeedWater = 3f;

	private float accelerationTimeGround = .05f;
//	private float accelerationTimeWater = .2f;

	private float velocityXSmoothing;
	private float velocityYSmoothing;

	private bool demonIsMoving;
	[HideInInspector]
	public bool isDemon;
	private string demonBind = "r";


	void Start () {
		controller = GetComponent <PlayerController>();
		isDemon = false; 
	}

	public void Update(){

		Movement ();

		if(Input.GetKeyDown(demonBind)){
			isDemon = !isDemon;
			DemonForm ();
		}
	}

	public void Movement(){
	
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical")).normalized;

		float targetVelocityX = input.x * moveSpeedGround;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, /*(groundLayer == true) ? */accelerationTimeGround /*: accelerationTimeWater*/); //här kan man updatera accelerationstiden baserat på underlag, water och mud variabler finns

		float targetVelocityY = input.y * moveSpeedGround;
		velocity.y = Mathf.SmoothDamp (velocity.y, targetVelocityY, ref velocityYSmoothing, /*(groundLayer == true) ? */accelerationTimeGround /*: accelerationTimeWater*/);

		controller.PlayerMove (velocity * Time.deltaTime, input);

	}

	void Attack(){
		
	}

	public void DemonForm(){
		if (isDemon) {
			moveSpeedGround += 2f;
		} else {
			moveSpeedGround = 5f;
		}
	}

//	public void takeDamage(float damage){
//		currentHealth -= damage;
//
//		if (currentHealth <= 0) {
//			this.transform.position = spawnPoint.position;
//			this.transform.rotation = spawnPoint.rotation;
//			currentHealth = maxHealth;
//		}
//	}
}
