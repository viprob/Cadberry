using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlaconController : MonoBehaviour {

	private AudioSource audio;
	private GameObject parent;

	void Awake(){
		parent = this.transform.parent.gameObject;
		audio = parent.GetComponent<AudioSource>();
	}
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Wagon") || other.gameObject.CompareTag ("Chocolat"))
		{
			audio.Play ();
			this.gameObject.SetActive (false);

		}
	}
}
