using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonController : MonoBehaviour {


	public float speed = 10f;
	public float jump = 7f;

	public LayerMask whatIsGround;
	private Transform groundCheck;

	private Rigidbody rb;


	void Start(){
		rb = GetComponent<Rigidbody>();
		groundCheck = this.transform.Find ("groundCheck");
	}

	void FixedUpdate(){
		SetSpeed ();
		CheckJump ();
	}


	private void SetSpeed(){
		rb.velocity = new Vector3 (speed, rb.velocity.y, rb.velocity.z);
	}


	private void CheckJump()
	{
		if (isGrounded())
		{
			if (Input.GetButton("Jump"))
			{
				rb.AddForce(new Vector3(0f, jump, 0f), ForceMode.Impulse);
			}
		}
	}

	private bool isGrounded(){
		return Physics.CheckSphere (groundCheck.position, 0.05f ,whatIsGround.value);
	}
}
