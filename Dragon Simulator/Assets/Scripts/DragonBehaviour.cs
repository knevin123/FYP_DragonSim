using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBehaviour : MonoBehaviour {

	public ParticleSystem flame;

	// Use this for initialization
	void Start () {
		flame = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			flame.Play ();
		}
		if (Input.GetButtonDown("Fire2"))
		{
			flame.Stop ();
		}

	}
}
