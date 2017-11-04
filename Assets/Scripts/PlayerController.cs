using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 10f;
	public Vector3 jump = new Vector3(0f, 10f ,0f);
	//public Vector3 gravity = new Vector3 (0f, -10f, 0f);

	private Vector3 nextVelocity;
	private bool grounded;
	private Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody>();
	}

	void Start(){

	}

	void FixedUpdate(){

		SetSpeed ();
		CheckJump();




		//nextVelocity = rb.velocity; //Init.
		//CheckJump();
		//SetGravity();
		//SetSpeed();
		Debug.Log("Grounded:" + grounded + "   x:"+nextVelocity.x + "  y:"+nextVelocity.y + "  z:"+nextVelocity.z);
		//rb.velocity = nextVelocity; //Apply change.
	}


	void SetGravity(){
		//nextVelocity += gravity;

	}


	void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}


	// Gère le saut du personnage, ainsi que son animation de saut
	void CheckJump()
	{
		if (true)//if (grounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				rb.AddForce(jump, ForceMode.Impulse);
				//grounded = false;
				//Debug.Log("passe ici");
				//nextVelocity += jump;

				}
		}
	}



	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag ("Ground")) {
			grounded = true;
		}
	}

}
	
