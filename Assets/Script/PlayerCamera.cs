using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

	public Transform target;
	public Vector3 offset = new Vector3(0f,1f,-10f);
	public float lookAheadOffset = 5f;
	public float camSpeed = 1f;
	float xlerp;
	float ylerp;
	float zlerp;
	float wlerp;

	private CharacterController2d charControl;

	void Start () {
		charControl = FindObjectOfType<CharacterController2d> ();
	}

	void FixedUpdate () {
		zlerp = Mathf.Lerp(zlerp, Input.GetAxis("Horizontal") * lookAheadOffset, Time.deltaTime * (camSpeed * 0.5f));
		wlerp = Mathf.Lerp(wlerp, Input.GetAxis("Vertical") * lookAheadOffset * 0.25f, Time.deltaTime * (camSpeed * 2f));
		xlerp = Mathf.Lerp (xlerp, target.position.x, Time.deltaTime * camSpeed);
		if (charControl.m_Grounded) {
			ylerp = Mathf.Lerp (ylerp, target.position.y, Time.deltaTime * camSpeed);
		}

		transform.position = new Vector3(xlerp + zlerp, ylerp + wlerp, 0f) + offset;
	}
}
