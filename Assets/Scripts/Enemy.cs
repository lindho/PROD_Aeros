using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class Enemy : MonoBehaviour {
	
	private float moveSpeed = 5f;

	private bool isAggro;
	private bool isMoving;
	private bool isIdle;
	private bool isAttacking;

	private Animator anim;

	public Transform target;
	public GameObject startPosition;

	void Start () {
		anim = GetComponent<Animator> ();
		isAggro = false;
		isMoving = false;
	}

	void Update () {
		Aggro ();
		Chase ();
	}

	void Aggro (){
		if ((startPosition.transform.position - target.transform.position).magnitude < 8f) {
			isAggro = true;
		} else if ((transform.position - startPosition.transform.position).magnitude > 15f) {
			isAggro = false;
		}
	}

	void Chase(){
		float attack = moveSpeed * Time.deltaTime;
		float retreat = (moveSpeed * 1.5f) * Time.deltaTime;
		float distance = Vector2.Distance (target.position, transform.position);

		if (isAggro) {


			if (distance < 1f) {
				transform.Translate (Vector3.zero);
				isAttacking = true;
			} else if (distance > 1f) {
				isAttacking = false;
				isMoving = true;
				isIdle = false;

				Vector3 diff = DirectionVector ();
				float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Euler (0f, 0f, rot_z + 90);

				transform.Translate (Vector3.down * attack);
			}

		} else if (!isAggro) {
			transform.position = Vector3.MoveTowards (transform.position, startPosition.transform.position, retreat);
			isIdle = false;
		} 

		if (transform.position == startPosition.transform.position) {
			isIdle = true;
		}

		if (isIdle) {
			isMoving = false;
		}

		anim.SetBool("isAttacking", isAttacking);
		anim.SetBool ("isMoving", isMoving);
	}

	Vector3 DirectionVector(){
		Vector3 diff = target.position - transform.position;
		diff.Normalize ();
		return diff;
	}
}
