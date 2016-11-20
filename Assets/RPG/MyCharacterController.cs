using UnityEngine;
using System.Collections;

public class MyCharacterController : MonoBehaviour {
	//public Transform target;
	public LayerMask  player;
	public Collider ground;
	//public float distance;
	public bool Grounded;
	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVel = 12;
		public float rotateVel = 100;
		public float jumpVel = 25;
		public float distToGround;
		public float SideVel = 12;
		//public LayerMask  ground;



	}

	[System.Serializable]
	public class PhysSettings
	{
		public float downAccel = 0.75f;
	}
	
	[System.Serializable]
	public class InputSettings
	{
		public float inputDelay = 0.1f;
		public string FORWARD_AXIS= "Vertical";
		//public string TURN_AXIS= "Horizontal";
		public string JUMP_AXIS= "Jump";
		public string MOUSE_ROTATION = "MouseRotation";
		public string RIGHT_SIDEMOVE_AXIS= "RightSideMove";
		public string LEFT_SIDEMOVE_AXIS= "LeftSideMove";
		//public string MOUSE_ROTATION2 = "MouseRotation2";
		

	}


	public MoveSettings moveSettings = new MoveSettings();
	public PhysSettings physSettings = new PhysSettings();
	public InputSettings inputSettings = new InputSettings();

	Vector3 velocity = Vector3.zero;
	Quaternion targetRotation;
	Rigidbody rBody;

	float forwardInput, turnIput, jumpInput,rotYInput,RightsidemoveInput,LeftsidemoveInput/*rotXInput*/;


	public Quaternion TargetRotation
	{get {return targetRotation;}}


	/* bool Grounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, moveSettings.distToGround, moveSettings.ground);
	}*/

	void Start() 
	{

		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
						rBody = GetComponent<Rigidbody> ();
				else
						Debug.LogError ("Персонажу нужен rigidbody");
		forwardInput = turnIput = jumpInput = rotYInput /*= RightsidemoveInput = LeftsidemoveInput*/ = 0;


	}
	

	void Update() 
	{
		
		/*if (ground.gameObject.tag == "Ground") {
			Grounded = true;
		}else if(ground.gameObject.tag != "Ground") {
			Grounded = false;
		}*/
		//distance =transform.position.y-target.position.y;
		GetInput ();
		Turn ();
		SideWalk ();

	}


	void FixedUpdate() 
	{
		Run ();
		Jump ();

		rBody.velocity = transform.TransformDirection(velocity);
	}
	
	
	void GetInput()
	{
		forwardInput = Input.GetAxis (inputSettings.FORWARD_AXIS);
		//RightsidemoveInput = Input.GetAxis(inputSettings.RIGHT_SIDEMOVE_AXIS);
		//LeftsidemoveInput = Input.GetAxis(inputSettings.LEFT_SIDEMOVE_AXIS);
		jumpInput = Input.GetAxisRaw(inputSettings.JUMP_AXIS);
		rotYInput = Input.GetAxis(inputSettings.MOUSE_ROTATION);
		//turnIput =Input.GetAxis(inputSettings.TURN_AXIS);
		//rotXInput = Input.GetAxis(inputSettings.MOUSE_ROTATION2);
	}


	void Run()
	{
		if (Mathf.Abs (forwardInput) > inputSettings.inputDelay) {
			velocity.z = forwardInput * moveSettings.forwardVel;
				} else
						velocity.z = 0;
	}

	void Turn()
	{
		if (rotYInput!=0){
			targetRotation *= Quaternion.AngleAxis (moveSettings.rotateVel * rotYInput * Time.deltaTime, Vector3.up);
			transform.rotation = targetRotation;
		}
	}
	void SideWalk()
	{if (Input.GetButton("RightSideMove")) {
			velocity.x = moveSettings.SideVel;
		
		}else if (Input.GetButton("LeftSideMove")) {
			velocity.x = -moveSettings.SideVel;
			
		}
		else velocity.x = 0;
	}

	
	void Jump()
	{
		if (jumpInput > 0 && Grounded ) 
		{
			velocity.y = moveSettings.jumpVel;
		}
		else if(jumpInput == 0 && Grounded) 
		{
			velocity.y=0;
		}
		else
		{
			velocity.y-=physSettings.downAccel;
		}
	}
	/*void OnTriggerEnter(Collider other) {
		
		if (ground.gameObject.tag == "Ground") {
			Grounded = true;
		}
	}
	void OnTriggerExit(Collider other) {
		
		if (ground.gameObject.tag == "Ground") {
			Grounded = false;
		}
	}*/
	void OnCollisionEnter(Collision collision) 
	{
		if (ground.gameObject.tag == "Ground") {
			Grounded = true;
		}
	}
	void OnCollisionExit(Collision collision) 
	{
		if (ground.gameObject.tag == "Ground") {
			Grounded = false;
		}
	}
	void OnCollisionStay(Collision collisionInfo) 
	{
		if (ground.gameObject.tag == "Ground") {
			Grounded = true;
		}
	}

}
