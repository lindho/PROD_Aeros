using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour {
	Vector3 velocity;
	Rigidbody myBody;

	void Start () {
		myBody = GetComponent<Rigidbody>();
	}
	
	public void Move(Vector3 _velocity){
		velocity = _velocity;
	}

	public void FixedUpdate(){
		myBody.MovePosition (myBody.position + velocity * Time.fixedDeltaTime);
	}
}