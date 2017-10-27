using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController2 : MonoBehaviour {

	public float speed = 5.0F;
	public float jumpSpeed = 5.5F;
	public Vector3 gravity = new Vector3(0.0F,-20.0F ,0.0F);

	public Vector3 pcVelocity;
	public Vector3 ccVelocity;
	public Vector3 cc2Velocity;
	private CharacterController pc;
	private CharacterController cc;
	private CharacterController cc2;

	private int state;
	private float diffY;

	private bool jump1;
	private bool jump2;
	bool pcIsGrounded;
	bool ccIsGrounded;



	void Awake(){
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController> ();
		cc = GameObject.FindGameObjectWithTag("Chocolat").GetComponent<CharacterController> ();
		cc2 = GameObject.FindGameObjectWithTag("GameController").GetComponent<CharacterController> ();
		state = 1;
		jump1 = false;
		jump2 = false;
	}

	// Use this for initialization
	void Start () {

		//Physics.IgnoreCollision(pc.GetComponent<Collider>(), cc.GetComponent<Collider>());

		state = 1;

		ccVelocity = new Vector3(speed,0.0F,0.0F);
		cc2Velocity = new Vector3(speed,0.0F,0.0F);
		pcVelocity = new Vector3(speed,0.0F,0.0F);

		float ccCurrenty = cc.transform.position.y;
		float pcCurrenty = pc.transform.position.y;
		diffY = ccCurrenty - pcCurrenty;
	}



	void Update(){
		jump1 = Input.GetButton ("Jump");
		jump2 = Input.GetKey (KeyCode.E);
		pcIsGrounded = ((pc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;
		ccIsGrounded = ((cc.collisionFlags & CollisionFlags.Below) != 0) ? true : false;


	}

	void FixedUpdate(){

		ajustPositionCC ();//On eut trouver mieux...

		//ATTACHÉ
		if (cc.transform.IsChildOf(pc.transform)){

			if (pcIsGrounded && jump1) {
				pcVelocity = new Vector3(speed,0.0F,0.0F);
				pcVelocity.y += jumpSpeed;
			}
			if (!pcIsGrounded) 
			{
				pcVelocity += gravity * Time.deltaTime;
			}
			if (jump2) {
				cc.transform.parent=null;
				ccVelocity = new Vector3(speed,0.0F,0.0F);
				ccVelocity.y += jumpSpeed;
				ccVelocity += gravity * Time.deltaTime;
				cc.Move(ccVelocity * Time.deltaTime);
			}

			pc.Move(pcVelocity * Time.deltaTime);
		
		//DETATTCHÉ
		}else{
			
			if (pcIsGrounded && jump1) {
				pcVelocity = new Vector3(speed,0.0F,0.0F);
				pcVelocity.y += jumpSpeed;
			}

			pcVelocity += gravity * Time.deltaTime;
			ccVelocity += gravity * Time.deltaTime;
			cc.Move(ccVelocity * Time.deltaTime);
			pc.Move(pcVelocity * Time.deltaTime);

		}

		if (ccIsGrounded) {
			cc.transform.SetParent (pc.transform);
		}


		Debug.Log ("PC V:" + pc.velocity.x + "   CC V:" + cc.velocity.x);
	/*

		switch (state) {
		case 1: //vitesse constante + gravity
			ccVelocity += gravity * Time.deltaTime;
			//cc2Velocity += gravity * Time.deltaTime;
			pcVelocity += gravity * Time.deltaTime;

			pc.Move (ccVelocity * Time.deltaTime);
			cc.Move (ccVelocity * Time.deltaTime);
			//cc2.Move (ccVelocity * Time.deltaTime);


			//Ajust.
			//pc.transform.SetPositionAndRotation (new Vector3 (ccCurrentx,pcCurrenty,pcCurrentz), new Quaternion(0,0,0,0));

			if (Input.GetButtonDown ("Jump")) {
				ccVelocity = new Vector3(speed,jumpSpeed,0.0F);
				pcVelocity = new Vector3(speed,jumpSpeed,0.0F);
				state = 2;
			}
			break;

		case 2: //Initialisation du saut vers le haut.
			
			ccVelocity += gravity * Time.deltaTime;
			pcVelocity += gravity * Time.deltaTime;

			pc.Move (ccVelocity * Time.deltaTime);
			cc.Move (ccVelocity * Time.deltaTime);

			//pc.transform.SetPositionAndRotation (new Vector3 (ccCurrentx, ccCurrenty - diffY, pcCurrentz), new Quaternion (0, 0, 0, 0));
			if (ccVelocity.y <= 0) {
				state = 1;
			}
			if (!((pc.collisionFlags & CollisionFlags.Below) != 0)) {
				state = 1;
			}
			break;

		case 3: //tomber par la gravité
			
			//ccVelocity += gravity * Time.deltaTime;
			//pc.Move (ccVelocity * Time.deltaTime);
			//cc.transform.SetPositionAndRotation (new Vector3 (pcCurrentx, pcCurrenty + diffY, ccCurrentz), new Quaternion (0, 0, 0, 0));

			//if ((pc.collisionFlags & CollisionFlags.Below) != 0) {
			//	state = 1;
			//}
			break;

		case 4:
			break;

		case 5:
			break;

		case 6:
			break;

		case 7:
			break;

		default:
			break;
		}*/


	}


	void HorizontalMove (){
		float ccCurrenty = cc.transform.position.y;
		float ccCurrentz = cc.transform.position.z;
		float pcCurrentx = pc.transform.position.x;
		float pcCurrenty = pc.transform.position.y;
		float pcCurrentz = pc.transform.position.z;

	}

	void ajustPositionCC(){
		float ccCurrentx = cc.transform.position.x;
		float ccCurrenty = cc.transform.position.y;
		float ccCurrentz = cc.transform.position.z;
		float pcCurrentx = pc.transform.position.x;
		float pcCurrenty = pc.transform.position.y;
		float pcCurrentz = pc.transform.position.z;
		cc.transform.SetPositionAndRotation (new Vector3 (pcCurrentx,ccCurrenty,ccCurrentz), new Quaternion(0,0,0,0));

	}

}
