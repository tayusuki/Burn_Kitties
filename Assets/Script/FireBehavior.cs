using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FireBehavior : MonoBehaviour {

	public bool playerSafeFloor = false;
	public float catHeight = 0.5f;

	void Start () { 
		if (!playerSafeFloor) {
			GetComponent<Animator> ().Play ("Fire", 0, Random.Range (0.0f, 1.0f));
		}
	}

	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.tag == "Cat") {
			hit.transform.position = transform.position + (Vector3.up * catHeight);
			StartCoroutine(hit.GetComponent<CatBehavior> ().Kill ());
		}
		if (hit.tag == "Player") {
			Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
		}
	}

	void OnCollisionEnter2D(Collision2D hit){
		if (hit.transform.tag == "Cat") {
			StartCoroutine(hit.transform.GetComponent<CatBehavior> ().Kill ());
		}
	}
}
