using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	public float moveSpeed = 5;

	void Start () {
	}
	
//	public void Move(Vector3 _velocity){
//		velocity = _velocity;
//	}

	public void FixedUpdate(){
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
		
			transform.Translate = (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.fixedDeltaTime, 0f, 0f));
		
		}

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {

			transform.Translate = (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.fixedDeltaTime, 0f));

		}
	}
}