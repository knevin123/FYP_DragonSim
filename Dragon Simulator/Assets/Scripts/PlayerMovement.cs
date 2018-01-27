using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	public float rotSpeed=40.0f;
	public float moveSpeed=10.0f;

	void Update()
	{


		if (Input.GetKey(KeyCode.W))
		{
			transform.Translate(0, 0, moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.up,rotSpeed*Time.deltaTime);
		}
	}
}

