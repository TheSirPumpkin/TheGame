using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {

	public Transform target;

	[System.Serializable]
	public class PositionSettings
	{
		public Vector3 targetPosOffset = new Vector3(0,1f,0);
		public float lookSmooth = 100f;
		public float distanceFromTarget = -8f;
		public float zoomSmooth = 10f;
		public float maxZoom = -2f;
		public float minZoom = - 15f;
	}

	[System.Serializable]
	public class OrbitSettings
	{
		public float xRotation = -20f;
		public float yRotation = -180f;
		public float maxXRotation = 5f;
		public float minXRotation = -85f;
		public float vOrbitSmooth = 150;
		public float hOrbitSmooth = 150;
	}

	[System.Serializable]
	public class InputSettings
	{
		public string ORBIT_HORIZONTAL_SNAP = "OrbitHorizontalSnap";
		public string ORBIT_HORIZONTAL = "OrbitHorizontal";
		public string ORBIT_VERTICAL = "OrbitVertical";
		public string ZOOM = "Mouse ScrollWheel";
		public string ZOOM_SNAP = "ZoomSnap";

	}
	public PositionSettings position = new PositionSettings();
	public OrbitSettings orbit = new OrbitSettings();
	public InputSettings input = new InputSettings();

	Vector3 targetPos = Vector3.zero;
	Vector3 destination = Vector3.zero;
	MyCharacterController charController;
	float vOrbitInput, hOrbitInput, zoomInput, hOrbitSnapInput, zoomSnapInput;



	void Start () 
	{
		SetCameraTarget (target);

		targetPos = target.position + position.targetPosOffset;
		destination = Quaternion.Euler (orbit.xRotation, orbit.yRotation+target.eulerAngles.y,0)*-Vector3.forward * position.distanceFromTarget;
		destination += targetPos;
		transform.position = destination;
	}
	void GetInput()
	{
		if (Input.GetMouseButton (1)) {
			vOrbitInput = Input.GetAxis (input.ORBIT_VERTICAL);
			hOrbitInput = Input.GetAxis(input.ORBIT_HORIZONTAL);
		} 
		vOrbitInput = Input.GetAxis (input.ORBIT_VERTICAL);
		hOrbitSnapInput = Input.GetAxisRaw(input.ORBIT_HORIZONTAL_SNAP);
		zoomInput = Input.GetAxisRaw (input.ZOOM);
		zoomSnapInput = Input.GetAxisRaw (input.ZOOM_SNAP);
		
	}
	void OrbitTarget ()
	{
		if (hOrbitSnapInput > 0) {
			orbit.yRotation=-180f;
		}
		orbit.xRotation += -vOrbitInput * orbit.vOrbitSmooth * Time.deltaTime;
		orbit.yRotation += -hOrbitInput * orbit.hOrbitSmooth * Time.deltaTime;
		if (orbit.xRotation > orbit.maxXRotation)
		{
			orbit.xRotation=orbit.maxXRotation;
		}
		if (orbit.xRotation < orbit.minXRotation)
		{
			orbit.xRotation=orbit.minXRotation;
		}
	}

	void ZoomInOnTarget ()
	{
		if (zoomSnapInput > 0) {
			position.distanceFromTarget=-8;
		}
		position.distanceFromTarget += zoomInput * position.zoomSmooth;
		if (position.distanceFromTarget > position.maxZoom) 
		{
			position.distanceFromTarget=position.maxZoom;
		}
		if (position.distanceFromTarget < position.minZoom) 
		{
			position.distanceFromTarget=position.minZoom;
		}
	}

	void Update()
	{

		GetInput ();
		OrbitTarget ();
		ZoomInOnTarget ();
	}


	public void SetCameraTarget(Transform t)
	{		

		target = t;

		if (target != null) 
		{
			if(target.GetComponent<MyCharacterController>())
			{
				charController = target.GetComponent<MyCharacterController>();
			}
			else
				Debug.LogError("Цели нужен MyCharacterController");
		}
		else
			Debug.LogError("Камере нужна цель");

	}

	void LateUpdate()
	{
	
		MoveToTarget ();
		LookAtTarget ();

	}

	void MoveToTarget()
	{
		targetPos = target.position + position.targetPosOffset;
		destination = Quaternion.Euler (orbit.xRotation, orbit.yRotation+target.eulerAngles.y,0)*-Vector3.forward * position.distanceFromTarget;
		destination += targetPos;
		transform.position = destination;

	}

	void LookAtTarget()
	{
		Quaternion targetRotation = Quaternion.LookRotation (targetPos - transform.position);
		transform.rotation = Quaternion.Lerp (transform.rotation, targetRotation, position.lookSmooth * Time.deltaTime);
	}


}
