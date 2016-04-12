using UnityEngine;
using System.Collections.Generic;

public class BallThrower : MonoBehaviour
{
	public GameObject ballPrefab;
	private GameObject ball;

	public GameObject spawnPos;
	public Vector3 throwDir = new Vector3(0, 0, -1);
	public float throwSpeed = 10;

	public float spawnTime = 1;
	private float spawnCounter = 0;

	public int maxNumBalls = 6;
	private GameObject[] ballsInPlay;

	// Use this for initialization
	void Start ()
	{
		ballsInPlay = GameObject.FindGameObjectsWithTag("Ball");
	}

	// Update is called once per frame
	void Update ()
	{
		
		if (ballsInPlay.Length < maxNumBalls)
		{
			spawnCounter += Time.deltaTime;
			if (spawnCounter > spawnTime)
			{
				ball = Instantiate(ballPrefab, spawnPos.transform.position, Quaternion.identity) as GameObject;
				ball.GetComponent<Rigidbody>().AddForce(throwDir * throwSpeed, ForceMode.Impulse);
				spawnCounter = 0;
			}
		}
	}

	void LateUpdate()
	{
		ballsInPlay = GameObject.FindGameObjectsWithTag("Ball");
	}
}
