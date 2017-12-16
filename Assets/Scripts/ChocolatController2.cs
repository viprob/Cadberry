using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolatController2 : MonoBehaviour {


	/*******************************************************
	* Les Attributs générale, qui s'applique a tout le script
	*******************************************************/
	public float speed = 10f;
	public float jump = 8f;
	private bool mustJump;

	private WagonController wagonScript;

	public LayerMask whatIsWagon;
	private GameObject wagon;
	private Rigidbody wagonRb;

	private Transform wagonCheck;
	private bool isOnWagon;
	private bool triggerOnWagon;

	private Rigidbody rb;
	private AudioSource audio;

	//private float offsetY;



	/*******************************************************
	* Les méthode de unity
	*******************************************************/
	//Executé 1 fois au debut
	void Awake(){
		rb = GetComponent<Rigidbody>();
		wagonCheck = this.transform.Find ("wagonCheck");
		wagon = GameObject.FindGameObjectsWithTag ("Wagon")[0];
		wagonRb = wagon.GetComponent<Rigidbody>();
		//offsetY = transform.position.y - wagon.transform.position.y;

		audio = GetComponent<AudioSource>();
		wagonScript = wagon.GetComponent<WagonController> ();
	}

	void Start(){
		isOnWagon = false;
		triggerOnWagon = false;
		mustJump = false;
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

	private float calculJumpForce(float pos){
		float minH = 2.31f; //Hardcoder en attendant... à revoir.
		float maxH = 5.86f; //Hardcoder en attendant... à revoir.

		float currentH = (pos - minH < 0) ? 0 : pos - minH;
		return -2.0f*currentH + 12.15f;

	}

	private void CheckJump()
	{
		if (isOnWagon)
		{
			//Set the trigger to jump at the right moment
			if (Input.GetKey(KeyCode.E))
			{
				
				isOnWagon = false;
				rb.mass = 1f;
				rb.velocity = new Vector3 (rb.velocity.x, 0f, 0f);

				float jumpForce = 0;
				Debug.Log (wagonScript.isGrounded);
				if (wagonScript.isGrounded) {
					jumpForce = jump;
				} else {
					jumpForce = calculJumpForce (transform.position.y);
				}		
					
				rb.AddForce(new Vector3(0f, jumpForce, 0f), ForceMode.Impulse);
			}

		
			//Jump here cause this is the right moment.
			/*
			if (mustJump && wagonRb.velocity.y <= 0) {
				mustJump = false;
				isOnWagon = false;
				rb.mass = 1f;
				rb.velocity = new Vector3 (rb.velocity.x, 0f, 0f);
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
			}
			*/

		}
	}

	private bool IsOnWagon(){
		return Physics.CheckSphere (wagonCheck.position, 0.01f ,whatIsWagon.value);
	}

}
