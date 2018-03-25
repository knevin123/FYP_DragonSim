using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosestHoop : MonoBehaviour {
	GameObject arrow;
	/*
	System.Collections.IEnumerator CloseHoop()
	{
		yield return new WaitForSeconds(1);
		while (true)
		{
			GameObject[] hoops = GameObject.FindGameObjectsWithTag("Hoop");
			GameObject target = GetClosestHoop (hoops);
			Debug.Log (target);
			if (target != null) {
				arrow.transform.LookAt (target.transform);
			}
			yield return new WaitForSeconds(0.1);
		}
	}
*/
	// Use this for initialization
	void OnEnable(){
		arrow = GameObject.FindGameObjectWithTag("Arrow");
		//StartCoroutine(CloseHoop());

	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] hoops = GameObject.FindGameObjectsWithTag("Hoop");
		GameObject target = GetClosestHoop (hoops);
		Debug.Log (target);
		if (target != null) {
			arrow.transform.LookAt (target.transform);
		}
	}

	GameObject GetClosestHoop(GameObject[] hoops){
		GameObject closestHoop = null;
		float minDist = Mathf.Infinity;
		Vector3 currentPos = transform.position;
		foreach (GameObject g in hoops) {
			float dist = Vector3.Distance (g.transform.position,currentPos);
			if(dist<minDist){
				closestHoop = g;
				minDist = dist;
			}
		}
		return closestHoop;
	}
}
