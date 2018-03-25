using UnityEngine;

public class AiManager : MonoBehaviour {

	public int targetCount = 6;
	public float radius = 200;
	float dist=0;
	public Vector3 toUser;
	public GameObject aiPrefab;
	public GameObject user;
	Vector3 target;

	System.Collections.IEnumerator SpawnDragons()
	{
		yield return new WaitForSeconds(1);
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
			//calculate distance to user
			/*for (int i = 0; i < enemies.Length; i++) {
				toUser=enemies[i].transform.position-user.transform.position;
				dist=toUser.magnitude;
				if (dist>300){
					DestroyImmediate(enemies[i]);
				}
			}*/
			yield return new WaitForSeconds(1);
		}
	}

	// Use this for initialization
	void OnEnable(){
		user = GameObject.FindGameObjectWithTag("User");
		StartCoroutine(SpawnDragons());

	}

	// Update is called once per frame
	void Update () {
	}
}
