using UnityEngine;
using System.Collections;


public class NTcam : MonoBehaviour {
	
	MyCharacterController characterController;
	public float movementSpeed = 5.0f;
	public float mouseSensitivity = 2.0f;
	public float jumpSpeed = 10.0f;
	public bool isGrounded;
	
	void Start () {
		
		characterController = GetComponent<MyCharacterController> ();
	}
	
	void FixedUpdate () {
	
		
		//Rotation
		float rotY = Input.GetAxis ("Mouse X") * mouseSensitivity;
		transform.Rotate (0, rotY, 0);
		

	}
}