using UnityEngine;

public class AiManager : MonoBehaviour {

	public int targetCount = 6;
	public float radius = 200;
	public GameObject aiPrefab;
	Vector3 target;

	System.Collections.IEnumerator SpawnDragons()
	{
		yield return new WaitForSeconds(3);
		while (true)
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("AI");
			if (enemies.Length < targetCount)
			{
				GameObject enemy = GameObject.Instantiate(aiPrefab);
				Vector2 c = Random.insideUnitCircle * radius;
				enemy.transform.position = new Vector3
					(c.x
						, 45
						, c.y
					);
			}
			yield return new WaitForSeconds(2);
		}
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnDragons());

	}

	// Update is called once per frame
	void Update () {
	}
}
