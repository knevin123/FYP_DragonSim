using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathWander : SteeringBehaviour {
	public float radius = 50;
	Vector3 target;
	Vector3 newTarget;
	private void OnDrawGizmos()
	{
		if (isActiveAndEnabled && Application.isPlaying)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, target);
		}
	}
	// Use this for initialization
	void Start () {
		Vector2 c = Random.insideUnitCircle * radius;
		target = new Vector3
			(c.x+boid.transform.position.x
			, Random.Range(10,30)
				, c.y+boid.transform.position.z
			);
	}

	// Update is called once per frame
	public override Vector3 Calculate () {
		float dist = Vector3.Distance (target, boid.transform.position);
		if (dist < 30) {
			Vector2 c = Random.insideUnitCircle * radius;
			target = new Vector3
				(c.x+boid.transform.position.x
					, Random.Range(10,30)
					, c.y+boid.transform.position.z
				);
		}
		return boid.SeekForce (target);
	}
}
