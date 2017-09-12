using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	Vector3 velocity;

	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

	public void FixedUpdate(){
		transform.position+=transform.forward + velocity *Time.fixedDeltaTime;
	}
}