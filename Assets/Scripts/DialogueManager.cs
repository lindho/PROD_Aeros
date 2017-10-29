using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public bool dialogueActive;

	void Start () {
		
	}

	void Update () {
		if (dialogueActive && Input.GetKeyDown (KeyCode.Space)) {		
			dBox.SetActive (false);
			dialogueActive = false;
		}
	}

	public void ShowBox(string dialogue){
		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}
}
