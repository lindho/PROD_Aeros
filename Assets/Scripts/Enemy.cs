using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController))]
public class Enemy : MonoBehaviour {

	private float attackDistanceThreshold;
	private float timeBetweenAttacks = 1;

	private float nextAttackTime;

	private float moveSpeed = 5f;
	private float health = 10;
	private float damage = 1;

	private bool isAggro;
	private bool isMoving;
	private bool isIdle;  

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

		if (Time.time > nextAttackTime) {
			float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
			if (sqrDstToTarget < Mathf.Pow (attackDistanceThreshold, 2)) {
				nextAttackTime = Time.time + timeBetweenAttacks;
				StartCoroutine (Attack ());
			}
		}
	}

	IEnumerator Attack(){
		Vector2 originalPosition = transform.position;
		Vector3 attackPosition = target.position;

		yield return null;
	}

	void Harm() {
		
	}

	void Aggro (){
		if ((startPosition.transform.position - target.transform.position).magnitude < 8f) {
			isAggro = true;
			//			transform.position = Vector3.MoveTowards (transform.position, target.position/* - offset*/, attack);
		} else if ((transform.position - startPosition.transform.position).magnitude > 15f) {
			isAggro = false;
			//ReturnToStartPoint ();
		}
	}

	//	void ReturnToStartPoint(){
	//		isAggro = false;
	//		float retreat = (moveSpeed*1.5f) * Time.deltaTime;
	//		transform.position = Vector3.MoveTowards (transform.position, startPosition.transform.position, retreat);
	//	}

	void Chase(){
		float attack = moveSpeed * Time.deltaTime;
		float retreat = (moveSpeed * 1.5f) * Time.deltaTime;
//		Vector2 realTarget = new Vector2 (target.position.x - 2 , target.position.y - 2);

		if (isAggro) { 
			transform.position = Vector3.MoveTowards (transform.position, target.position, attack);
			isMoving = true;
			isIdle = false;

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

		anim.SetBool ("isMoving", isMoving);
	}

	IEnumerator delay(){
		float rate = 1;
		yield return new WaitForSeconds (rate);
	}
}
