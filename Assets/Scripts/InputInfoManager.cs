using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputInfoManager : MonoBehaviour {

	public Image interactionImage;
	private bool insideZone;

	void Start () {
		interactionImage.canvasRenderer.SetAlpha (0.0f);
	}

	IEnumerator Pulsing(){
		while (insideZone) {
			FadeIn ();
			yield return new WaitForSeconds (0.5f);
			FadeOut ();
			yield return new WaitForSeconds (1f);
		}
	}

	void FadeIn(){
		interactionImage.CrossFadeAlpha (1.0f, 1f, false);
	}

	void FadeOut(){
		interactionImage.CrossFadeAlpha (0.0f, 1f, false);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			insideZone = true;
			StartCoroutine (Pulsing ());
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			interactionImage.canvasRenderer.SetAlpha (0.0f);
			insideZone = false;
		}
	}
}