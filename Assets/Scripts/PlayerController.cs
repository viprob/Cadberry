using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 15.0F;
	public float jumpSpeed = 5.5F;
	public Vector3 gravity = new Vector3(0.0F,-20.0F ,0.0F);

	public Vector3 velocity;
	private CharacterController cc;

	void Awake(){
		cc = GetComponent<CharacterController> ();

	}

	void Update()
	{
		bool isGrounded = ((cc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;
		if (isGrounded)
		{
			
			if (Input.GetButtonDown("Jump"))
			{
				velocity = new Vector3(speed,0.0F,0.0F);
				velocity.y += jumpSpeed;
			}
		}
	}

	void FixedUpdate()
	{
		bool isGrounded = ((cc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;
		if (!isGrounded) 
		{
			velocity += gravity * Time.deltaTime;
		}
		cc.Move(velocity * Time.deltaTime);
		//Debug.Log (isGrounded);
		//Debug.Log ("x: " + velocity.x* Time.deltaTime + ", y: " + velocity.y* Time.deltaTime + ", z: "+ velocity.z* Time.deltaTime);
		//Debug.Log(transform.GetChild(0).name);
	}

}
	
