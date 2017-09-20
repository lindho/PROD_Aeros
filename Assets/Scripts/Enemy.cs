using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	float attackDistanceThreshold;
	float timeBetweenAttacks = 1;

	float nextAttackTime;

	bool isAggro;
	public Transform target;
	float moveSpeed = 3f;
	public GameObject startPosition;

	void Start () {
		isAggro = false;
	}

	void Update () {
		Aggro ();

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
		isAggro = true;
		float attack = moveSpeed * Time.deltaTime;
		if ((transform.position - target.transform.position).magnitude < 10f && isAggro) {
			transform.position = Vector3.MoveTowards (transform.position, target.position/* - offset*/, attack);
		} else if ((transform.position - target.transform.position).magnitude > 10f) {
			ReturnToStartPoint ();
		}
	}

	void ReturnToStartPoint(){
		isAggro = false;
		float retreat = (moveSpeed*1.5f) * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, startPosition.transform.position, retreat);
	}
}
