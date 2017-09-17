using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	Vector2 offset;
	bool isAggro;
	public Transform target;
	float enemySpeed = 3f;
	private Vector2 startPosition;

	void Start () {
		isAggro = false;
		startPosition = transform.position;
	}

	void Update () {
		Aggro ();
	}

	void Harm() {
		
	}

	void Attack(){
		
	}

	void Aggro (){
		float attack = enemySpeed * Time.deltaTime;
		if (transform.position.magnitude <= 10) {
			isAggro = true;
			transform.position = Vector3.MoveTowards (transform.position, target.position/* - offset*/, attack);
		} else if (transform.position.magnitude >= 10) {
			ReturnToStartPoint ();
		}
	}

	void ReturnToStartPoint(){
		isAggro = false;
		float retreat = (enemySpeed) * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, startPosition, retreat);
	}
}
