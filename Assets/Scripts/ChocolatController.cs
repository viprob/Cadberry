using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolatController : MonoBehaviour {


	/*******************************************************
	* Les Attributs générale, qui s'applique a tout le script
	*******************************************************/
	public float speed = 10f;
	public float jump = 6f;

	public LayerMask whatIsWagon;
	private Transform wagonCheck;
	private bool isOnWagon;
	private bool triggerOnWagon = false;

	private Rigidbody rb;
	private AudioSource audio;

	private GameObject wagon;
	//private float offsetY;



	/*******************************************************
	* Les méthode de unity
	*******************************************************/
	//Executé 1 fois au debut
	void Awake(){
		rb = GetComponent<Rigidbody>();
		wagonCheck = this.transform.Find ("wagonCheck");
		wagon = GameObject.FindGameObjectsWithTag ("Wagon")[0];
		//offsetY = transform.position.y - wagon.transform.position.y;

		audio = GetComponent<AudioSource>();
	}

	//Executé a chaque frame.
	void FixedUpdate(){
		isOnWagon = IsOnWagon ();
		SetSpeed ();
		SetMass ();
		CheckJump ();
		AjustPosition ();
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Wagon")){
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
		if (isOnWagon) {
			rb.mass = 0.0000001f;
			if (rb.velocity.y > 0)
				rb.velocity = new Vector3 (speed, 0f, rb.velocity.z);
		}
		else 
			rb.mass = 1f;
	}

	private void AjustPosition(){
		transform.SetPositionAndRotation(new Vector3(wagon.transform.position.x, transform.position.y, transform.position.z),new Quaternion());
	}

	private void CheckJump()
	{
		if (isOnWagon)
		{
			if (Input.GetKey(KeyCode.E))
			{
				isOnWagon = false;
				rb.mass = 1f;
				rb.velocity = new Vector3 (rb.velocity.x, 0f, 0f);
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
			}
		}
	}

	private bool IsOnWagon(){
		return Physics.CheckSphere (wagonCheck.position, 0.01f ,whatIsWagon.value);
	}
		
}
