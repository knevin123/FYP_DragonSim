using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopScore : MonoBehaviour {
	public ScoreController sController;
	public GameObject score;
	// Use this for initialization
	void Start () {
		score= GameObject.FindWithTag ("Score");
		sController = score.GetComponent<ScoreController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		Debug.Log (other.name + " has entered");
		if (other.gameObject.tag == "User")
		{
			Destroy (gameObject);
			sController.score++;
		}
	}
}
