using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashFade : MonoBehaviour {

	public Image splashImage;
	public string loadLevel;
	private AudioSource source;

	void Awake(){
		source = GetComponent<AudioSource> ();
		splashImage.canvasRenderer.SetAlpha (0.0f);
	}

	IEnumerator Start(){
		source.Play ();
		FadeIn ();
		yield return new WaitForSeconds (4f);
		FadeOut ();
		yield return new WaitForSeconds (3f);
		if (!source.isPlaying) {
			SceneManager.LoadScene (loadLevel);
		}
	}

	void FadeIn(){
		splashImage.CrossFadeAlpha (1.0f, 5f, false);
	}

	void FadeOut(){
		splashImage.CrossFadeAlpha (0.0f, 1f, false);
	}
}
