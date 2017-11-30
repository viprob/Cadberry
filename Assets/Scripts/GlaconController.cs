using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlaconController : MonoBehaviour {
	
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Wagon") || other.gameObject.CompareTag ("Chocolat"))
		{
			this.gameObject.SetActive (false);
		}
	}
}
