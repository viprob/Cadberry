using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour {

	/*******************************************************
	* Les Attributs générale, qui s'applique a tout le script
	*******************************************************/
	public float speed = 10f;
	public float jump = 9.24f;

	public LayerMask whatIsGround;
	private Transform groundCheck;

	private Rigidbody rb;
	private AudioSource audioSaut;
	private AudioSource audioRoue;


	/*******************************************************
	* Les méthode de unity
	*******************************************************/
	void Start(){
		rb = GetComponent<Rigidbody>();
		groundCheck = this.transform.Find ("groundCheck");

		AudioSource[] audios = GetComponents<AudioSource>();
		audioSaut = audios[0];
		audioRoue = audios[1];
	}

	void FixedUpdate(){
		if (!isGrounded()) {
			audioRoue.Stop ();
		}
		SetSpeed ();
		CheckJump ();
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Ground")){
			audioRoue.Play ();
		}
	}


	/*******************************************************
	* Mes méthodes
	*******************************************************/
	private void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}


	private void CheckJump()
	{
		if (isGrounded())
		{
			if (Input.GetButton("Jump"))
			{
				rb.velocity = new Vector3 (rb.velocity.x, 0f, 0f);
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
				audioSaut.Play ();
			}
		}
	}

	private bool isGrounded(){
		return Physics.CheckSphere (groundCheck.position, 0.08f ,whatIsGround.value);
	}
}
