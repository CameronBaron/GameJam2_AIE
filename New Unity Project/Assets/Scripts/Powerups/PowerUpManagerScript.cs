using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUpManagerScript : MonoBehaviour {


	public List<GameObject> powerUpSpawners = new List<GameObject>();

	public GameObject powerupspawner;

	public int maxSpawners;
	public float coolDown = 2.5f;
	float defaultCoolDown = 10;
	// Use this for initialization
	void Start ()
	{
		//for (int i = powerUpSpawners.Count; i < maxSpawners; i++)
		//{
		//	Vector3 newPos;
		//	newPos.x = Random.Range(-4.0f, 4.0f);
		//	newPos.y = 0;
		//	newPos.z = Random.Range(-4.0f, 4.0f);
		//	GameObject newSpawner = Instantiate(powerupspawner, newPos, Quaternion.identity) as GameObject;
		//	powerUpSpawners.Add(newSpawner);
		//	//newSpawner.SetActive(false);
		//}
	}
	
	// Update is called once per frame
	void Update ()
	{
		coolDown -= Time.deltaTime;
		if (coolDown <= 0)
		{
			int randNum = Random.Range(0, powerUpSpawners.Count);
			//powerUpSpawners[randNum].GetComponent<GameObject>().SetActive(true);

			powerUpSpawners[randNum].GetComponent<PowerUpSpawnerScript>().isActive = true;

			coolDown = defaultCoolDown;
		}
		Debug.Log("amount of spawners: " + powerUpSpawners.Count.ToString());
	}


}
