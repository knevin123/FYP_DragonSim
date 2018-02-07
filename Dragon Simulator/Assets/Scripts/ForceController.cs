using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour {

	Rigidbody rb;
	public float power=1000;
	public float angularpower = 100;
	public bool useCamera;
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
	void Walk(float units)
	{
		rb.AddForce (owner.transform.forward*units);
	}
	void Strafe(float units)
	{
		rb.AddForce (owner.transform.right*units);
	}
	void Yaw(float units)
	{
		rb.AddTorque (Vector3.up*units);
	}
	void Up(float units)
	{
		rb.AddForce (Vector3.up * units);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log (Time.deltaTime);
		float walk = Input.GetAxis ("Vertical");
		Walk (walk*power*Time.deltaTime);

		float strafe = Input.GetAxis ("Horizontal");
		Strafe (strafe*power*Time.deltaTime);

		float yaw = Input.GetAxis ("YawAxis");
		Yaw (yaw * power * Time.deltaTime);

		float fly = Input.GetAxis ("UpDown");
		Up ( fly* power * Time.deltaTime);
		
	}
}
