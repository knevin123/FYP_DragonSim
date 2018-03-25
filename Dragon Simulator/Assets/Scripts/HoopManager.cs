using UnityEngine;

public class HoopManager : MonoBehaviour {

	public int targetCount = 5;
	public float radius = 200;
	float dist=0;
	public Vector3 toUser;
	public GameObject hoopPrefab;
	public GameObject user;
	Vector3 target;
	bool collected;

	System.Collections.IEnumerator SpawnHoops()
	{
		yield return new WaitForSeconds(1);
		while (true)
		{
			GameObject[] hoops = GameObject.FindGameObjectsWithTag("Hoop");
			if (hoops.Length==targetCount) {
				collected = false;
			}
			if(hoops.Length==0){
				collected=true;
			}
			if (collected)
			{
				GameObject hoop = GameObject.Instantiate(hoopPrefab);
				Vector2 c = Random.insideUnitCircle * radius;
				hoop.transform.position = new Vector3
					(c.x
						, 45
						, c.y
					);
			}
			yield return new WaitForSeconds(1);
		}
	}

	// Use this for initialization
	void OnEnable(){
		user = GameObject.FindGameObjectWithTag("User");
		StartCoroutine(SpawnHoops());

	}

	// Update is called once per frame
	void Update () {
	}
}
