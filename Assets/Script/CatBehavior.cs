using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBehavior : MonoBehaviour {

	Animator anim;
	Rigidbody2D rb;
	public bool dead = false;
	public bool thrown = false;

	public bool running = false;
	public float runSpeed = 4f; 
	public float runTimer = 1f;
	float runTime;

	public bool sleeping = false;

	bool facingRight = true;

	public Collider2D stickCollider;
	public PhysicsMaterial2D stickyMat;
	public PhysicsMaterial2D slippyMat;


	const float k_GroundedRadius = .35f;
	public LayerMask m_WhatIsGround;							
	public bool m_Grounded;
	public Transform m_GroundCheck;

	public ParticleSystem fire;
	public ParticleSystem smoke;

	private AudioSource sndPlayer;
	public AudioClip[] nyan;
	public AudioClip thudSnd;
	public AudioClip dieSnd;
	public AudioClip extinguishSnd;

	void Start () {
		sndPlayer = GetComponent<AudioSource> ();
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		runTime = runTimer;
	}
	
	void Update () {
		if (running && m_Grounded) {
			if (runTimer > 0f) {
				runTimer -= Time.deltaTime;
			} else {
				Flip ();
				rb.velocity = Vector2.zero;
				runSpeed = -runSpeed;
				runTimer = runTime;
			}
			anim.SetFloat ("Speed", 1f);
			rb.AddForce (Vector2.right * runSpeed);
			stickCollider.sharedMaterial = slippyMat;
		} else {
			anim.SetFloat ("Speed", 0f);
			stickCollider.sharedMaterial = stickyMat;
		}

		if (sleeping) {
			anim.SetBool ("Sleeping", true);
		} else {
			anim.SetBool ("Sleeping", false);
		}

		if (thrown) {
			if (m_Grounded) {
				sndPlayer.PlayOneShot (thudSnd);
				thrown = false;
			}
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			StartCoroutine(Kill ());
		}
	}

	private void FixedUpdate()
	{
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
		// This can be done using layers instead but Sample Assets will not overwrite your project settings.
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject && !colliders[i].gameObject.transform.IsChildOf(this.transform))
			{
				m_Grounded = true;
			}
		}

		anim.SetBool ("Grounded", m_Grounded);
	}

	public void Thrown(){
		anim.SetTrigger ("Thrown");
		sleeping = false;
		thrown = true;
	}

	void Flip(){
		if (facingRight) {
			GetComponent<SpriteRenderer> ().flipX = true;
			facingRight = false;
		} else {
			GetComponent<SpriteRenderer> ().flipX = false;
			facingRight = true;
		}
	}

	public IEnumerator Kill(){
		if (!dead) {
			sndPlayer.PlayOneShot (dieSnd);
			dead = true;
			rb.velocity = Vector2.zero;
			rb.isKinematic = true;
			transform.tag = "Untagged";
			anim.SetTrigger ("Die");
			fire.Play ();
			yield return new WaitForSeconds (2f);
			GetComponent<SpriteRenderer> ().sortingOrder = -1;
			smoke.Play ();
			sndPlayer.PlayOneShot (extinguishSnd);
		}
	}
}
