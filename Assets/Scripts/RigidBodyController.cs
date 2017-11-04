using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyController : MonoBehaviour {
	
	public float speed = 10f;
	public float jump = 10f;

	private Rigidbody rb;

	void Awake(){
		rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate(){
		SetSpeed ();
		CheckJump ();
	}

	void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}

	void CheckJump()
	{
		if (true)//if (grounded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
			}
		}
	}
}
