using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCongrats : MonoBehaviour {

	public AudioClip catsnd;
    public GameObject part;

	void Start () {
		if (GameManager.beatGame) {
            Time.timeScale = 1;
            StopAllCoroutines();
			StartCoroutine (Play ());
			GameManager.beatGame = false;
		}
	}
	
    /*
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			StartCoroutine (Play ());
		}
	}*/
	

	IEnumerator Play(){
		GetComponent<AudioSource> ().Play ();
        part.GetComponent<ParticleSystem>().Stop();
        part.SetActive( true);
        part.GetComponent<ParticleSystem>().Play();
        Debug.Log(part.GetComponent<ParticleSystem>().isPlaying);
        yield return new WaitForSeconds (13f);
        part.GetComponent<ParticleSystem>().Stop();
        yield return new WaitForSeconds (3.5f);
		GetComponent<AudioSource> ().PlayOneShot (catsnd);
	}
}
