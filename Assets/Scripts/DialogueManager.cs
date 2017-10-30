using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	private PlayerController player;

	public string[] dialogueLines;

	[HideInInspector]
	public int currentLine;
	[HideInInspector]
	public bool dialogueActive;

	void Update () {
		if (dialogueActive && Input.GetKeyDown (KeyCode.E)) {		
			currentLine++;
		}

		if (currentLine >= dialogueLines.Length) {
			dBox.SetActive (false);
			dialogueActive = false;

			currentLine = 0;
		}
		dText.text = dialogueLines [currentLine];
	}

	public void ShowBox(string dialogue){
		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}

	public void ShowDialogue(){
		dialogueActive = true;
		dBox.SetActive (true);
	}
}