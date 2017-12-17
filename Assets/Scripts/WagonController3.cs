using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController3 : MonoBehaviour {

	/*******************
	 *  LES ATTRIBUTS  *
	 *******************/
	public float speed = 10f;
	public float jumpVelocity = 9.24f;

	//Fine tuning for better jump
	public float fallMultiplier = 2.5f;
	public float lowJumpMultiplier = 2f;

	public LayerMask whatIsGround;
	private Transform groundCheck;
	public bool isGrounded;

	private Rigidbody rb;
	private AudioSource audioSaut;
	private AudioSource audioRoue;

	/*******************************************************
	* Les méthode de unity
	*******************************************************/
	void Start(){
		rb = GetComponent<Rigidbody> ();
		groundCheck = this.transform.Find ("groundCheck");

		AudioSource[] audios = GetComponents<AudioSource>();
		audioSaut = audios[0];
		audioRoue = audios[1];
	}

	void FixedUpdate(){
		isGrounded = IsGrounded ();
		if (!isGrounded) {
			audioRoue.Stop ();
		}
		SetSpeed ();
		Jump ();
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Ground")){
			audioRoue.Play ();
		}
	}
	/*

	}*/


	/*******************************************************
	* Mes méthodes
	*******************************************************/
	private void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}


	private void Jump()
	{
		if (isGrounded)
		{
			//Start the jump
			if (Input.GetButtonDown ("Jump")) {
				rb.velocity = new Vector3( rb.velocity.x ,jumpVelocity, rb.velocity.z);
				audioSaut.Play ();
			}
		}

		//When falling
		if (rb.velocity.y < 0) {
			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		}
		//When 

		else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")){
			rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
		}
	}

	private bool IsGrounded(){
		return Physics.CheckSphere (groundCheck.position, 0.08f ,whatIsGround.value);
	}
}
