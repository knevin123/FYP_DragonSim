using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMove : MonoBehaviour {

	public int forwardspeed=2;
	public int rotatespeed=3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(Vector3.left*rotatespeed);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(Vector3.right*rotatespeed);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.down*rotatespeed);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.up*rotatespeed);
		}
		transform.Translate(0, 0,  forwardspeed* Time.deltaTime);	
	}
}
