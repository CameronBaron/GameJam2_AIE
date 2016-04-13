using UnityEngine;
using System.Collections;

public class PowerUpSpawnerScript : MonoBehaviour {

	public float spawnTimer;
	public GameObject powerup;
	int objectCount = 0;
	public bool isActive = false;
	public GameObject spawnManager;

	// Use this for initialization
	void Start ()
	{
		spawnManager.GetComponent<PowerUpManagerScript>().powerUpSpawners.Add(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isActive)
		{
			spawnTimer -= Time.deltaTime;
			if (spawnTimer <= 0 && objectCount != 20)
			{
				Vector3 newPos;
				newPos.x = transform.position.x;
				newPos.y = transform.position.y + .5f;
				newPos.z = transform.position.z;
				GameObject newPowerup = Instantiate(powerup, newPos, Quaternion.identity) as GameObject;
				spawnTimer = 5;
				objectCount++;
				//Debug.Log("amount of powerups: " + objectCount.ToString());
				isActive = false;
			}
		}
	}
}
