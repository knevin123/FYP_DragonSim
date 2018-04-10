using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {
	public int score;
	Text text;
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();

		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}
}
