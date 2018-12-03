using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinsih : MonoBehaviour {

	public int catsNeededToFinish = 1;
	public TextMesh needMoreText;

	void Start () {
		needMoreText.color = new Color (1f, 1f, 1f, 0f);
	}

	void OnTriggerEnter2D(Collider2D hit) {
		if (hit.tag == "Player") {
			Debug.Log (hit.GetComponent<PlayerPickup> ().heldCats.Count);
			if (hit.GetComponent<PlayerPickup> ().heldCats.Count >= catsNeededToFinish) {
				Debug.Log ("You win");			
			} else {
				StartCoroutine(ShowText ());
			}
		}
	}

	void OnTriggerExit2D(Collider2D hit) {
		if (hit.tag == "Player" && needMoreText.color.a != 0f) {
			StartCoroutine(HideText ());
		}
	}

	public IEnumerator ShowText() {
		float counter = 0f;
		while (counter < 1f) {
			needMoreText.color = new Color (1f, 1f, 1f, counter);
			counter += 0.1f;
			yield return new WaitForEndOfFrame ();
		}
	}

	public IEnumerator HideText(){
		float counter = 1f;
		while (counter > 0f) {
			needMoreText.color = new Color (1f, 1f, 1f, counter);
			counter -= 0.1f;
			yield return new WaitForEndOfFrame ();
		}
		needMoreText.color = new Color (1f, 1f, 1f, 0f);
	}
}
