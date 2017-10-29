using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	void Start () {
		dMan = FindObjectOfType <DialogueManager>();
	}
	

	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyUp (KeyCode.Space)) {
				dMan.ShowBox (dialogue);
			}
		}
	}
}
