using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAnimation : MonoBehaviour {

	Animator anim;
	Rigidbody rb;
	private GameObject owner;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		owner=this.gameObject;
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
	void Update () {

		float strafe = Input.GetAxis ("Horizontal");
		if (strafe > 0.5) {
			anim.SetBool ("Right", true);
		} else {
			anim.SetBool ("Right", false);
		}
		if (strafe < -0.5) {
			anim.SetBool ("Left", true);
		} else {
			anim.SetBool ("Left", false);
		}
	}
}
