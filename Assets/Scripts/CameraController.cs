using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		float cameraPositionX = player.transform.position.x + offset.x;
		float cameraPositionY = player.transform.position.y + offset.y;
		float cameraPositionZ = player.transform.position.z + offset.z;

		transform.position = new Vector3 (cameraPositionX, transform.position.y, cameraPositionZ); //Ici on ne change pas la position en Y.
    }
}
