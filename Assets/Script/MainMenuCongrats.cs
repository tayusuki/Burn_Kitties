using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCongrats : MonoBehaviour {

	public AudioClip catsnd;

	void Start () {
		if (GameManager.beatGame) {
			StartCoroutine (Play ());
			GameManager.beatGame = false;
		}
	}
	/*
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			StartCoroutine (Play ());
		}
	}
	*/

	IEnumerator Play(){
		GetComponent<AudioSource> ().Play ();
		GetComponent<ParticleSystem> ().Play ();
		yield return new WaitForSeconds (13f);
		GetComponent<ParticleSystem> ().Stop ();
		yield return new WaitForSeconds (3.5f);
		GetComponent<AudioSource> ().PlayOneShot (catsnd);
	}
}
