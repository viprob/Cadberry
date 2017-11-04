using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController1 : MonoBehaviour {

	public float speed = 10f;
	public float jump = 10f;

	private Rigidbody rb;
	private bool onChar;


	void Awake(){
		rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate(){
		Debug.Log (onChar);
		SetSpeed ();
		//SetMass()
		CheckJump ();
	}

	void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}

	void SetMass(){
		rb.mass = (onChar) ? 0.0000001f : 1f;
	}

	void CheckJump()
	{
		if (true)//if (grounded)
		{
			if (Input.GetKeyDown(KeyCode.E))
			{
				rb.mass = 1f;
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
				onChar = false;
			}
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.CompareTag ("Player")) {
			onChar = true;
			rb.mass = 0.0000001f;
		}
	}

	void OnCollisionExit(Collision coll){
		if (coll.gameObject.CompareTag ("Player")) {
			onChar = false;
			rb.mass = 1f;
		}
	}
}
