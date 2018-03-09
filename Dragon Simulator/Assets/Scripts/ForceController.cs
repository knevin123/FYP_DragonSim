using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour {

	Rigidbody rb;
	public float power=100f;
	public float turnpower = 40f;
	public float forwardspeed=40f;
	public bool useCamera;
	Vector3 forward;
	int walk=1;
	private GameObject owner;
	// Use this for initialization
	void Start () {
		if (useCamera) {
			owner = Camera.main.gameObject;
        } else {
			owner=this.gameObject;
		}
		rb = GetComponent<Rigidbody> ();
	}
	void Strafe(float units)
	{
		rb.AddForce (owner.transform.right*units);
	}
	void Yaw(float angle)
	{
		float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
		float threshold = 0.95f;
		if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold)))
		{
			return;
		}
		// A pitch is a rotation around the right vector
		Quaternion rot = Quaternion.AngleAxis(angle, transform.up);

		rb.transform.rotation = rot * rb.transform.rotation;
	}
	void Up(float units)
	{
		rb.AddForce (Vector3.up * units);
	}
	void RotateUp(float angle)
	{
		float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
		float threshold = 0.95f;
		if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold)))
		{
			return;
		}
		// A pitch is a rotation around the right vector
		Quaternion rot = Quaternion.AngleAxis(angle, transform.right);

		rb.transform.rotation = rot * rb.transform.rotation;
	}
	void RotateDown(float units)
	{
		
	}

	// Update is called once per frame
	void FixedUpdate () {

		rb.transform.position += rb.transform.forward * forwardspeed*Time.deltaTime;

		//float strafe = Input.GetAxis ("Horizontal");
		//Strafe (strafe*power*Time.deltaTime);

		float yaw = Input.GetAxis ("Horizontal");
		Yaw (yaw * turnpower * Time.deltaTime);

		float fly = Input.GetAxis ("Vertical");
		Up ( fly* power * Time.deltaTime);
		RotateUp ( -fly*turnpower*Time.deltaTime);

	}
}
