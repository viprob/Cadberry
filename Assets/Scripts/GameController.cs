using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float speed = 8.0F;
	public float jumpSpeed = 5.5F;
	public Vector3 gravity = new Vector3(0.0F,-20.0F ,0.0F);

	public Vector3 pcVelocity;
	public Vector3 ccVelocity;
	private CharacterController pc;
	private CharacterController cc;
	private float diffY;

	void Awake(){
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController> ();
		cc = GameObject.FindGameObjectWithTag("Chocolat").GetComponent<CharacterController> ();
	}

	void Start(){
		float ccCurrenty = cc.transform.position.y;
		float pcCurrenty = pc.transform.position.y;
		diffY = ccCurrenty - pcCurrenty;

		ccVelocity = new Vector3(speed,0.0F,0.0F);
		pcVelocity = new Vector3(speed,0.0F,0.0F);
	}
	void Update()
	{

	}

	void FixedUpdate()
	{
		bool pcIsGrounded = ((pc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;
		bool ccIsGrounded = ((cc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;

		Debug.Log (ccIsGrounded);


		//jump Chocolat
		if (ccIsGrounded)
		{
			
			if (Input.GetKey(KeyCode.E))
			{
				ccVelocity = new Vector3(speed,0.0F,0.0F);
				ccVelocity.y += jumpSpeed;
				//cc.Move(ccVelocity * Time.deltaTime);

			}
			if (Input.GetButtonDown ("Jump")) {
				ccVelocity = new Vector3 (speed, 0.0F, 0.0F);
				ccVelocity.y += jumpSpeed;
				//cc.Move(ccVelocity * Time.deltaTime);

				//cc.transform.SetPositionAndRotation (new Vector3 (ccCurrentx,pcCurrenty+diffY,ccCurrentz), new Quaternion(0,0,0,0));


			}

		}
		if (!ccIsGrounded) 
		{
			ccVelocity += gravity * Time.deltaTime;

		}
			
		// jump Player
		if (pcIsGrounded)
		{

			if (Input.GetButtonDown("Jump"))
			{
				pcVelocity = new Vector3 (speed, 0.0F, 0.0F);
				pcVelocity.y += jumpSpeed;
			}
		}
		if (!pcIsGrounded) 
		{
			pcVelocity += gravity * Time.deltaTime;
		}
			

		//Move
		pc.Move(pcVelocity * Time.deltaTime);
		cc.Move(ccVelocity * Time.deltaTime);



		//Just to be sure that cc is always align with pc
		float ccCurrentx = cc.transform.position.x;
		float ccCurrenty = cc.transform.position.y;
		float ccCurrentz = cc.transform.position.z;
		float pcCurrentx = pc.transform.position.x;
		float pcCurrenty = pc.transform.position.y;
		float pcCurrentz = pc.transform.position.z;
		if (ccCurrenty - pcCurrenty < diffY) {
			cc.transform.SetPositionAndRotation (new Vector3 (pcCurrentx,pcCurrenty+diffY,ccCurrentz), new Quaternion(0,0,0,0));

		} else {
			cc.transform.SetPositionAndRotation (new Vector3 (pcCurrentx,ccCurrenty,ccCurrentz), new Quaternion(0,0,0,0));

		}
			
		//CC

		//Debug.Log (isGrounded);
		//Debug.Log ("x: " + pcVelocity.x* Time.deltaTime + ", y: " + pcVelocity.y* Time.deltaTime + ", z: "+ pcVelocity.z* Time.deltaTime);
		//Debug.Log(transform.GetChild(0).name);
	}

}