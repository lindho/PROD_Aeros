using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	public string dialogue;
	private DialogueManager dMan;

	public string[] dialogueLines;

	void Start () {
		dMan = FindObjectOfType <DialogueManager>();
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			
			if (Input.GetKeyUp (KeyCode.E) && !dMan.dialogueActive) {
				dMan.dialogueLines = dialogueLines;
				dMan.currentLine = 0;
				dMan.ShowDialogue ();
			}
		}
	}
}