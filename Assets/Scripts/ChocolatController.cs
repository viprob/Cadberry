using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolatController : MonoBehaviour {


	/*******************************************************
	* Les Attributs générale, qui s'applique a tout le script
	*******************************************************/
	public float speed = 10f;
	public float jump = 5f;

	public LayerMask whatIsWagon;
	private Transform wagonCheck;
	private bool isOnWagon;
	private bool triggerOnWagon = false;

	private Rigidbody rb;
	private AudioSource audio;



	/*******************************************************
	* Les méthode de unity
	*******************************************************/
	//Executé 1 fois au debut
	void Awake(){
		rb = GetComponent<Rigidbody>();
		wagonCheck = this.transform.Find ("wagonCheck");
		audio = GetComponent<AudioSource>();
	}

	//Executé a chaque frame.
	void FixedUpdate(){
		isOnWagon = IsOnWagon ();

		SetMass ();
		SetSpeed ();
		CheckJump ();
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Player")){
			audio.Play ();
		}
	}



	/******************************************************
	* Mes méthodes
	*******************************************************/

	private void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}

	private void SetMass(){
		rb.mass = (isOnWagon) ? 0.0000001f : 1f;
	}

	private void CheckJump()
	{
		if (isOnWagon)
		{
			if (Input.GetKey(KeyCode.E))
			{
				rb.mass = 1f;
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
			}
		}
	}

	private bool IsOnWagon(){
		return Physics.CheckSphere (wagonCheck.position, 0.05f ,whatIsWagon.value);
	}
		
}
