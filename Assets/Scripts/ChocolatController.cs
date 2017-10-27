using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolatController : MonoBehaviour {
	
	public float speed = 15.0F;
	public float jumpSpeed = 5.5F;
	public Vector3 gravity = new Vector3(0.0F,-20.0F ,0.0F);

	private Vector3 velocity;
	private CharacterController cc;
	private GameObject parent;
	private PlayerController pc;

	void Awake(){
		cc = GetComponent<CharacterController> ();
		velocity = new Vector3(speed,0.0F,0.0F);
		parent = GameObject.FindGameObjectWithTag("Player");

	}

	void Update(){


	}

	void FixedUpdate()
	{
		

	}

}

/*
		bool isGrounded = ((cc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;
		if (isGrounded)
		{
			transform.SetParent(parent.transform);
			if (Input.GetKey(KeyCode.E))
			{
				transform.parent = null;
				cc.Move(velocity * Time.deltaTime);
				velocity = new Vector3(speed,0.0F,0.0F);
				velocity.y += jumpSpeed;
			}
		}
		if (!isGrounded) 
		{
			velocity += gravity * Time.deltaTime;
			cc.Move(velocity * Time.deltaTime);
		}

		cc.Move(velocity * Time.deltaTime);
		//Debug.Log ("x: " + velocity.x* Time.deltaTime + ", y: " + velocity.y* Time.deltaTime + ", z: "+ velocity.z* Time.deltaTime);
		//Debug.Log(transform.IsChildOf (parent.transform));
*/