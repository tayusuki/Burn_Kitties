using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

	public GameObject catVisPrefab;
	public List<GameObject> heldCats;
	public List<GameObject> storedCats;

	public float catHeight = 0.5f;
	public float catTowerHeight = 1.5f;
	Coroutine catAddingInstance;

	public LayerMask ignoreCheck;
	[Range(0,1)] public float maxLean = 0.5f;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			if (catAddingInstance == null && FindClosestGato() != null) {
				catAddingInstance = StartCoroutine (AddGato (FindClosestGato()));
			}
		}

		if (Input.GetKeyDown (KeyCode.V)) {
			//RemoveTopGato ();
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			if (heldCats.Count > 0 && catAddingInstance == null) {
				StartCoroutine(ThrowGato());
			}
		}
	}

	GameObject FindClosestGato(){
		GameObject closeCat = null;
		foreach(Collider2D hit in Physics2D.OverlapCircleAll(GetComponent<CharacterController2d>().transform.position, 0.5f)){
			float bestdist = Mathf.Infinity;
			if (hit.tag == "Cat") {
				if (Vector2.Distance (GetComponent<CharacterController2d>().m_GroundCheck.position, hit.transform.position) < bestdist) {
					closeCat = hit.gameObject;
				}
			}
		}
		Debug.Log (closeCat);
		return closeCat;
	}

	IEnumerator AddGato(GameObject targetGato){
		storedCats.Add (targetGato);
		targetGato.SetActive(false);
		yield return new WaitForEndOfFrame ();
		 
		if (Physics2D.OverlapCircleAll(new Vector2 (transform.position.x, transform.position.y + catTowerHeight + catHeight), 0.25f, ignoreCheck).Length != 0 && heldCats.Count > 0) {
			RemoveTopGato ();
		}

		heldCats.Add(Instantiate(catVisPrefab));
		heldCats[heldCats.Count - 1].transform.parent = this.transform;
		catTowerHeight += catHeight;
		float elapsedTime = 0f;
		while (elapsedTime < 1f) {
			for (int i = 0; i < heldCats.Count; i++) {
				heldCats [i].transform.localPosition = Vector2.Lerp (new Vector2 (0f, catTowerHeight - (catHeight * i)), new Vector2 (0f, catTowerHeight - (catHeight * (i - 1))), elapsedTime); 
				elapsedTime += Time.deltaTime * 4f;
				yield return new WaitForEndOfFrame ();
			}
		}
		catAddingInstance = null;
	}

	IEnumerator ThrowGato(){
		if (GetComponent<CharacterController2d> ().m_FacingRight) {
			storedCats [storedCats.Count - 1].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			storedCats [storedCats.Count - 1].transform.position = transform.position + (Vector3.up * 1.5f) + (Vector3.right*1f);
			yield return new WaitForSeconds(0.1f);
			storedCats [storedCats.Count - 1].SetActive (enabled);
			storedCats [storedCats.Count - 1].GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10f, ForceMode2D.Impulse);
		} else {
			storedCats [storedCats.Count - 1].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			storedCats [storedCats.Count - 1].transform.position = transform.position + (Vector3.up * 1.5f) + (Vector3.left*1f);
			yield return new WaitForSeconds(0.1f);
			storedCats [storedCats.Count - 1].SetActive (enabled);
			storedCats [storedCats.Count - 1].GetComponent<Rigidbody2D>().AddForce(Vector2.right * -10f, ForceMode2D.Impulse);
		}
		catAddingInstance = StartCoroutine (RemoveBotGato ());
	}

	void RemoveTopGato(){
		if (GetComponent<CharacterController2d> ().m_FacingRight) {
			storedCats [0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			storedCats [0].transform.position = transform.position + (Vector3.up * 0.75f) + (Vector3.right*0.25f);
			storedCats [0].SetActive (enabled);
		} else {
			storedCats [0].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			storedCats [0].transform.position = transform.position + (Vector3.up * 0.75f) + (Vector3.left*0.25f);
			storedCats [0].SetActive (enabled);
		}
		GameObject.Destroy (heldCats [0].gameObject);
		//create cat object
		heldCats.RemoveAt (0);
		storedCats.RemoveAt (0);
		catTowerHeight -= catHeight;
	}

	IEnumerator RemoveBotGato(){
		GameObject.Destroy (heldCats [heldCats.Count - 1].gameObject);
		//create cat object
		heldCats.RemoveAt (heldCats.Count - 1);
		storedCats.RemoveAt (storedCats.Count - 1);
		//resort cats
		for (int i = heldCats.Count - 1; i >= 0; i--) {
			float elapsedTime = 0f;
			while (elapsedTime < 1f) {
				heldCats [i].transform.localPosition = Vector2.Lerp(heldCats [i].transform.localPosition, new Vector2 (0f, catTowerHeight - (catHeight * i)), elapsedTime);

				elapsedTime += Time.deltaTime * 10f;
				yield return new WaitForEndOfFrame();
			}
		}
		catTowerHeight -= catHeight;
		catAddingInstance = null;
	}
}
