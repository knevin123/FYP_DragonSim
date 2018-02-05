
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject dragon;


	float speed = 200.0f;
	// Use this for initialization
	void Start()
	{
	}

	void Yaw(float angle)
	{
		Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
		transform.rotation = rot * transform.rotation;
	}

	void Roll(float angle)
	{
		Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = rot * transform.rotation;
	}

	void Pitch(float angle)
	{
		float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
		float threshold = 0.95f;
		if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold)))
		{
			return;
		}

		// A pitch is a rotation around the right vector
		Quaternion rot = Quaternion.AngleAxis(angle, transform.right);

		transform.rotation = rot * transform.rotation;
	}

	void Walk(float units)
	{
		transform.position += transform.forward * units;
	}

	void Fly(float units)
	{
		transform.position += Vector3.up * units;
	}

	void Strafe(float units)
	{
		transform.position += transform.right * units;
	}

	// Update is called once per frame
	void Update () {
		float mouseX, mouseY;
		float speed = this.speed;
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");
		Yaw(mouseX);
		Pitch(-mouseY);

		//change position to above the dragon
		transform.position = dragon.transform.position;
	}

}